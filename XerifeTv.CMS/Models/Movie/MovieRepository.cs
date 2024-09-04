using Microsoft.Extensions.Options;
using MongoDB.Driver;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.MongoDB;

namespace XerifeTv.CMS.Models.Movie;

public sealed class MovieRepository(IOptions<DBSettings> options) 
  : BaseRepository<MovieEntity>(ECollection.MOVIES, options), IMovieRepository
{
  public async Task<IEnumerable<MovieEntity>> GetByTitle(string title)
  {
    var response = await _collection.Find(r => 
      r.Title.Contains(title, StringComparison.CurrentCultureIgnoreCase))
        .ToListAsync();

    return response;
  }
}