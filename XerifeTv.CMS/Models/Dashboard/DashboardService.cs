using XerifeTv.CMS.Models.Abstractions;
using XerifeTv.CMS.Models.Channel.Interfaces;
using XerifeTv.CMS.Models.Dashboard.Dtos.Response;
using XerifeTv.CMS.Models.Dashboard.Interfaces;
using XerifeTv.CMS.Models.Movie.Interfaces;
using XerifeTv.CMS.Models.Series.Interfaces;

namespace XerifeTv.CMS.Models.Dashboard;

public sealed class DashboardService(
  IMovieRepository _movieRepository,
  ISeriesRepository _seriesRepository,
  IChannelRepository _channelRepository) : IDashboardService
{
  public async Task<Result<GetDashboardDataRequestDto>> Get()
  {
    var response = await Task.WhenAll([
      _movieRepository.CountAsync(),
      _seriesRepository.CountAsync(),
      _channelRepository.CountAsync()
    ]);

    return Result<GetDashboardDataRequestDto>.Success(
      new GetDashboardDataRequestDto(response[0], response[1], response[2]));
  }
}
