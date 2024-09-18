using Microsoft.Extensions.Options;
using MongoDB.Driver;
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
  public async Task<PagedList<SeriesEntity>> GetByFilterAsync(GetSeriesByFilterRequestDto dto)
  {
    Expression<Func<SeriesEntity, bool>> filterExpression = dto.Filter switch
    {
      ESeriesSearchFilter.CATEGORY => r => r.Category.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase),
      _ => r => r.Title.Contains(dto.Search, StringComparison.CurrentCultureIgnoreCase)
    };

    FilterDefinition<SeriesEntity> filter = Builders<SeriesEntity>.Filter.Where(filterExpression);

    var count = await _collection.CountDocumentsAsync(filter);
    var items = await _collection.Find(filter)
      .SortBy(r => r.Title)
      .Skip(dto.LimitResults * (dto.CurrentPage - 1))
      .Limit(dto.LimitResults)
      .ToListAsync();

    var totalPages = (int)Math.Ceiling(count / (decimal)dto.LimitResults);

    return new PagedList<SeriesEntity>(dto.CurrentPage, totalPages, items);
  }

  public async Task<string> CreateEpisodeAsync(string serieId, Episode episode)
  {
    var response = await _collection
      .Find(r => r.Id.Equals(serieId))
      .FirstOrDefaultAsync();

    response.Episodes.Add(episode);
    await _collection.ReplaceOneAsync(r => r.Id.Equals(response.Id), response);

    return episode.Id;
  }
}