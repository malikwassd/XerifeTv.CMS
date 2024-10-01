using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Content.Dtos.Response;
using XerifeTv.CMS.Models.Content.Interfaces;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.Models.Movie.Enums;
using XerifeTv.CMS.Models.Series.Interfaces;
using XerifeTv.CMS.Models.Series.Dtos.Request;
using XerifeTv.CMS.Models.Series.Enums;

namespace XerifeTv.CMS.Models.Content;

public sealed class ContentService(
  IMovieRepository _movieRepository,
  ISeriesRepository _seriesRepository) : IContentService
{
  const int limitTotalResult = 50;
  const int limitPartialResult = 2;

  public async Task<Result<IEnumerable<ItemsByCategory<GetMovieContentResponseDto>>>> GetMoviesGroupByCategory(
    int? limit)
  {
    var response = await _movieRepository.GetGroupByCategoryAsync(limit ?? limitPartialResult);

    var result = response.Select(x =>
      new ItemsByCategory<GetMovieContentResponseDto>(
        x.Category, x.Items.Select(GetMovieContentResponseDto.FromEntity)));

    return Result<IEnumerable<ItemsByCategory<GetMovieContentResponseDto>>>
      .Success(result);
  }

  public async Task<Result<IEnumerable<GetMovieContentResponseDto>>> GetMoviesByCategory(
    string category, int? limit)
  {
    var response = await _movieRepository.GetByFilterAsync(
      new GetMoviesByFilterRequestDto(
        EMovieSearchFilter.CATEGORY, category, limit ?? limitTotalResult, 1));

    return Result<IEnumerable<GetMovieContentResponseDto>>
      .Success(response.Items.Select(GetMovieContentResponseDto.FromEntity));
  }

  public async Task<Result<IEnumerable<ItemsByCategory<GetSeriesContentResponseDto>>>> GetSeriesGroupByCategory(
    int? limit)
  {
    var response = await _seriesRepository.GetGroupByCategoryAsync(limit ?? limitPartialResult);

    var result = response.Select(x =>
      new ItemsByCategory<GetSeriesContentResponseDto>(
        x.Category, x.Items.Select(GetSeriesContentResponseDto.FromEntity)));

    return Result<IEnumerable<ItemsByCategory<GetSeriesContentResponseDto>>>
      .Success(result);
  }

  public async Task<Result<IEnumerable<GetSeriesContentResponseDto>>> GetSeriesByCategory(
    string category, int? limit)
  {
    var response = await _seriesRepository.GetByFilterAsync(
      new GetSeriesByFilterRequestDto(
        ESeriesSearchFilter.CATEGORY, category, limit ?? limitTotalResult, 1));

    return Result<IEnumerable<GetSeriesContentResponseDto>>
      .Success(response.Items.Select(GetSeriesContentResponseDto.FromEntity));
  }
}
