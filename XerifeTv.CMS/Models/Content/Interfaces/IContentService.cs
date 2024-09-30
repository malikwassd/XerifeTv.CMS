using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Content.Dtos.Response;

namespace XerifeTv.CMS.Models.Content.Interfaces;

public interface IContentService
{
  Task<Result<IEnumerable<ItemsByCategory<GetMovieContentResponseDto>>>> GetMoviesGroupByCategory(int? limit);
  Task<Result<IEnumerable<GetMovieContentResponseDto>>> GetMoviesByCategory(string category, int? limit);
}
