using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Enums;

namespace XerifeTv.CMS.Models.Movie.Interfaces;

public interface IMovieRepository : IBaseRepository<MovieEntity>
{
  Task<IEnumerable<MovieEntity>> GetByFilter(ESearchFilter filter, string value);  
}
