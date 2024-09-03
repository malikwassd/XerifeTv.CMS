using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class MoviesController(IMovieService _service) : Controller
{
  public async Task<IActionResult> Index()
  {
    if (!Request.QueryString.HasValue)
    {
      var _response = await _service.Get();

      if (_response.IsSuccess) ViewData["data"] = _response.Data;

      return View();
    }

    var search = Request.QueryString.Value?.Split('?')[1];

    var response = await _service.GetByTitle(search ?? "");

    if (response.IsSuccess) ViewData["data"] = response.Data;

    return View();
  }

  public async Task<IActionResult> Form(string? id)
  {
    if (id is not null)
    {
      var response = await _service.Get(id);
      if (response.IsSuccess) ViewData["data"] = response.Data;
    }

    return View();
  }

  public async Task<IActionResult> CreateForm(CreateMovieRequestDto dto)
  {
    await _service.Create(dto);

    return RedirectToAction("Index");
  }

  public async Task<IActionResult> UpdateForm(UpdateMovieRequestDto dto)
  {
    await _service.Update(dto);

    return RedirectToAction("Index");
  }

  public async Task<IActionResult> Delete(string? id)
  {
    if (id is not null) await _service.Delete(id);

    return RedirectToAction("Index");
  }


}
