using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Content.Dtos.Response;
using XerifeTv.CMS.Models.Content.Interfaces;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.Models.Movie.Enums;

namespace XerifeTv.CMS.Models.Content;

public sealed class ContentService(IMovieRepository _movieRepository) : IContentService
{
  const int limitTotalResults = 50;
  const int limitPartialResults = 6;

  public async Task<Result<IEnumerable<GetMovieContentResponseDto>>> GetMoviesByCategory(
    string category)
  {
    var response = await _movieRepository.GetByFilterAsync(
      new GetMoviesByFilterRequestDto(
        EMovieSearchFilter.CATEGORY, category, limitTotalResults, 1));

    return Result<IEnumerable<GetMovieContentResponseDto>>
      .Success(response.Items.Select(GetMovieContentResponseDto.FromEntity));
  }
}
