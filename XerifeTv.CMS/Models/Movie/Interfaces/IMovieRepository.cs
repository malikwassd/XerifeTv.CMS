using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Abstractions.Repositories;
using XerifeTv.CMS.Models.Movie.Dtos.Request;

namespace XerifeTv.CMS.Models.Movie.Interfaces;

public interface IMovieRepository : IBaseRepository<MovieEntity>
{
  Task<PagedList<MovieEntity>> GetByFilterAsync(GetMoviesByFilterRequestDto dto);  
}
