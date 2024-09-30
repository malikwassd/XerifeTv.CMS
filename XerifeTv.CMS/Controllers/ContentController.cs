using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Content.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class ContentController(IContentService _service) : Controller
{
  public async Task<JsonResult> Movies(string category)
  {
    var response = await _service.GetMoviesByCategory(category);

    if (response.IsSuccess) return Json(response.Data);

    return Json(Enumerable.Empty<string>());
  }
}
