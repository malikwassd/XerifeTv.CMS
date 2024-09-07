﻿using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Linq.Expressions;
using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Enums;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Movie;

public sealed class MovieRepository(IOptions<DBSettings> options) 
  : BaseRepository<MovieEntity>(ECollection.MOVIES, options), IMovieRepository
{
  public async Task<PagedList<MovieEntity>> GetByFilter(GetMoviesByFilterRequestDto dto)
  {
    Expression<Func<MovieEntity, bool>> filterExpression = dto.Filter switch
    {
      ESearchFilter.TITLE => r => r.Title.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase),
      ESearchFilter.CATEGORY => r => r.Category.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase),
      ESearchFilter.RELEASE_YEAR => r => r.ReleaseYear.Equals(int.Parse(dto.Search)),
      _ => r => r.Title.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase)
    };

    FilterDefinition<MovieEntity> filter = Builders<MovieEntity>.Filter.Where(filterExpression); 

    var count = await _collection.CountDocumentsAsync(filter);
    var items = await _collection.Find(filter)
      .Skip(dto.LimitResults * (dto.CurrentPage - 1))
      .Limit(dto.LimitResults)
      .ToListAsync();

    return new PagedList<MovieEntity>(dto.CurrentPage, (count / dto.LimitResults), items);
  }
}