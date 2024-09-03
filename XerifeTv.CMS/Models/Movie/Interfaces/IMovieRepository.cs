using XerifeTv.CMS.Models.Abstractions.Repositories;

namespace XerifeTv.CMS.Models.Movie.Interfaces;

public interface IMovieRepository : IBaseRepository<MovieEntity>
{
  Task<IEnumerable<MovieEntity>> GetByTitle(string title);  
}
