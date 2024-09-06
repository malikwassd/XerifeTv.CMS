using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Dtos.Response;
using XerifeTv.CMS.Models.Movie.Enums;

namespace XerifeTv.CMS.Models.Movie.Interfaces;

public interface IMovieService
{
  Task<Result<PagedList<GetMoviesResponseDto>>> Get(int currentPage, int limit);
  Task<Result<GetMovieResponseDto?>> Get(string id);
  Task<Result<string>> Create(CreateMovieRequestDto dto);
  Task<Result<string>> Update(UpdateMovieRequestDto dto);
  Task<Result<bool>> Delete(string id);
  Task<Result<IEnumerable<GetMoviesResponseDto>>> GetByFilter(ESearchFilter filter, string value);
}
