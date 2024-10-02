using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Content.Interfaces;

namespace XerifeTv.CMS.Controllers;

[Route("Api/Content")]
[ApiController]
public class ContentController(IContentService _service) : ControllerBase
{
  [HttpGet]
  [Route("Movies")]
  public async Task<IActionResult> Movies(int? limit)
  {
    var response = await _service.GetMoviesGroupByCategory(limit);
    return Ok(response.IsSuccess ? response.Data : []);
  }

  [HttpGet]
  [Route("Movies/{category}")]
  public async Task<IActionResult> MoviesCategory(string category, int? limit)
  {
    var response = await _service.GetMoviesByCategory(category, limit);
    return Ok(response.IsSuccess ? response.Data : []);
  }

  [HttpGet]
  [Route("Series")]
  public async Task<IActionResult> Series(int? limit)
  {
    var response = await _service.GetSeriesGroupByCategory(limit);
    return Ok(response.IsSuccess ? response.Data : []);
  }

  [HttpGet]
  [Route("Series/{category}")]
  public async Task<IActionResult> SeriesCategory(string category, int? limit)
  {
    var response = await _service.GetSeriesByCategory(category, limit);
    return Ok(response.IsSuccess ? response.Data : []);
  }

  [HttpGet]
  [Route("Series/Episodes/{serieId}/{season}")]
  public async Task<IActionResult> SeriesEpisodes(string serieId, int season)
  {
    var response = await _service.GetEpisodesSeriesBySeason(serieId, season);
    return Ok(response.IsSuccess ? response.Data : []);
  }

  [HttpGet]
  [Route("Channels")]
  public async Task<IActionResult> Channels(int? limit)
  {
    var response = await _service.GetChannelsGroupByCategory(limit);
    return Ok(response.IsSuccess ? response.Data : []);
  }
}
