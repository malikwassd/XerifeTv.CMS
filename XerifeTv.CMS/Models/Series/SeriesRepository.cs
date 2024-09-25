using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Core.Servers;
using System.Linq.Expressions;
using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Series.Dtos.Request;
using XerifeTv.CMS.Models.Series.Enums;
using XerifeTv.CMS.Models.Series.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Series;

public sealed class SeriesRepository(IOptions<DBSettings> options) 
  : BaseRepository<SeriesEntity>(ECollection.SERIES, options), ISeriesRepository
{
  public override async Task<PagedList<SeriesEntity>> GetAsync(int currentPage, int limit)
  {
    var projection = Builders<SeriesEntity>.Projection.Exclude(r => r.Episodes);

    var count = await _collection.CountDocumentsAsync(_ => true);
    var items = await _collection.Find(_ => true)
      .Project<SeriesEntity>(projection)
      .SortByDescending(r => r.CreateAt)
      .Skip(limit * (currentPage - 1))
      .Limit(limit)
      .ToListAsync();

    var totalPages = (int)Math.Ceiling(count / (decimal)limit);

    return new PagedList<SeriesEntity>(currentPage, totalPages, items);
  }

  public override async Task<SeriesEntity?> GetAsync(string id)
  {
    var projection = Builders<SeriesEntity>.Projection.Exclude(r => r.Episodes);

    var response = await _collection
      .Find(r => r.Id == id)
      .Project<SeriesEntity>(projection)
      .FirstOrDefaultAsync();

    return response;
  }

  public async Task<PagedList<SeriesEntity>> GetByFilterAsync(GetSeriesByFilterRequestDto dto)
  {
    Expression<Func<SeriesEntity, bool>> filterExpression = dto.Filter switch
    {
      ESeriesSearchFilter.CATEGORY => r => r.Category.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase),
      _ => r => r.Title.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase)
    };

    FilterDefinition<SeriesEntity> filter = Builders<SeriesEntity>.Filter.Where(filterExpression);
    var projection = Builders<SeriesEntity>.Projection.Exclude(r => r.Episodes);

    var count = await _collection.CountDocumentsAsync(filter);
    var items = await _collection.Find(filter)
      .Project<SeriesEntity>(projection)
      .SortBy(r => r.Title)
      .Skip(dto.LimitResults * (dto.CurrentPage - 1))
      .Limit(dto.LimitResults)
      .ToListAsync();

    var totalPages = (int)Math.Ceiling(count / (decimal)dto.LimitResults);

    return new PagedList<SeriesEntity>(dto.CurrentPage, totalPages, items);
  }

  public async Task<SeriesEntity?> GetEpisodesBySeasonAsync(string serieId, int season)
  {
    var filter = Builders<SeriesEntity>.Filter.Eq(r => r.Id, serieId);
    
    var projection = Builders<SeriesEntity>.Projection
      .Include(r => r.Title)
      .Include(r => r.NumberSeasons)
      .Include(r => r.Episodes)
      .ElemMatch(r => r.Episodes, e => e.Season == season);
    
    var response = await _collection
      .Find(filter)
      .Project<SeriesEntity>(projection)
      .FirstOrDefaultAsync();

    return response;
  }

  public override async Task UpdateAsync(SeriesEntity entity)
  {
    var filter = Builders<SeriesEntity>.Filter.Eq(r => r.Id, entity.Id);

    var update = Builders<SeriesEntity>.Update
      .Set(r => r.Title, entity.Title)
      .Set(r => r.Category, entity.Category)
      .Set(r => r.Synopsis, entity.Synopsis)
      .Set(r => r.Review, entity.Review)
      .Set(r => r.PosterUrl, entity.PosterUrl)
      .Set(r => r.BannerUrl, entity.BannerUrl)
      .Set(r => r.NumberSeasons, entity.NumberSeasons)
      .Set(r => r.ReleaseYear, entity.ReleaseYear)
      .Set(r => r.ParentalRating, entity.ParentalRating)
      .Set(r => r.UpdateAt, DateTime.UtcNow);

    await _collection.UpdateOneAsync(filter, update);
  }
}