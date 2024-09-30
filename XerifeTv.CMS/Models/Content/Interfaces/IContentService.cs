using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Content.Dtos.Response;

namespace XerifeTv.CMS.Models.Content.Interfaces;

public interface IContentService
{
  Task<Result<IEnumerable<GetMovieContentResponseDto>>> GetMoviesByCategory(string category);
}
