using Microsoft.Extensions.Options;
using MongoDB.Driver;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Enums;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Movie;

public sealed class MovieRepository(IOptions<DBSettings> options) 
  : BaseRepository<MovieEntity>(ECollection.MOVIES, options), IMovieRepository
{
  public async Task<IEnumerable<MovieEntity>> GetByFilter(ESearchFilter filter, string value)
  {
    return filter switch
    {
      ESearchFilter.TITLE 
        => await _collection.Find(r =>
            r.Title.Contains(value, StringComparison.CurrentCultureIgnoreCase))
              .ToListAsync(),

      ESearchFilter.CATEGORY 
        => await _collection.Find(r =>
            r.Category.Contains(value, StringComparison.CurrentCultureIgnoreCase))
              .ToListAsync(),

      ESearchFilter.RELEASE_YEAR 
        => await _collection.Find(r =>
            r.ReleaseYear.Equals(int.Parse(value)))
              .ToListAsync(),

      _ => [],
    };
  }
}