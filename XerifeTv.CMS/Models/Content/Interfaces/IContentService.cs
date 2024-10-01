using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Content.Dtos.Response;
using XerifeTv.CMS.Models.Series;

namespace XerifeTv.CMS.Models.Content.Interfaces;

public interface IContentService
{
  Task<Result<IEnumerable<ItemsByCategory<GetMovieContentResponseDto>>>> GetMoviesGroupByCategory(int? limit);
  Task<Result<IEnumerable<GetMovieContentResponseDto>>> GetMoviesByCategory(string category, int? limit);
  Task<Result<IEnumerable<ItemsByCategory<GetSeriesContentResponseDto>>>> GetSeriesGroupByCategory(int? limit);
  Task<Result<IEnumerable<GetSeriesContentResponseDto>>> GetSeriesByCategory(string category, int? limit);
  Task<Result<IEnumerable<Episode>>> GetEpisodesSeriesBySeason(string serieId, int season);
  Task<Result<IEnumerable<ItemsByCategory<GetChannelContentResponseDto>>>> GetChannelsGroupByCategory(int? limit);
}
