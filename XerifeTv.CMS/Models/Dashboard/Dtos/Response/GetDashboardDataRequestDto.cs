namespace XerifeTv.CMS.Models.Dashboard.Dtos.Response;

public record class GetDashboardDataRequestDto(
  long NumberOfMovies,
  long NumberOfSeries,
  long NumberOfChannels);