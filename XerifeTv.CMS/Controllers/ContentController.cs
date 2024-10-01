using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Content.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class ContentController(IContentService _service) : Controller
{
  public async Task<JsonResult> Movies(int? limit)
  {
    var response = await _service.GetMoviesGroupByCategory(limit);

    if (response.IsSuccess) return Json(response.Data);

    return Json(Enumerable.Empty<string>());
  }

  public async Task<JsonResult> MoviesCategory(string category, int? limit)
  {
    var response = await _service.GetMoviesByCategory(category, limit);

    if (response.IsSuccess) return Json(response.Data);

    return Json(Enumerable.Empty<string>());
  }

  public async Task<JsonResult> Series(int? limit)
  {
    var response = await _service.GetSeriesGroupByCategory(limit);

    if (response.IsSuccess) return Json(response.Data);

    return Json(Enumerable.Empty<string>());
  }

  public async Task<JsonResult> SeriesCategory(string category, int? limit)
  {
    var response = await _service.GetSeriesByCategory(category, limit);

    if (response.IsSuccess) return Json(response.Data);

    return Json(Enumerable.Empty<string>());
  }
}
