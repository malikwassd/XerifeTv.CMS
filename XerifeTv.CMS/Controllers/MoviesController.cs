using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Movie.Dtos.Request;
using XerifeTv.CMS.Models.Movie.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class MoviesController(IMovieService _service) : Controller
{
  public async Task<IActionResult> Index()
  {
    var response = await _service.Get();

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

  public async Task<IActionResult> FormPost(CreateMovieRequestDto dto)
  {
    var id = Request.Form["id"];

    if (string.IsNullOrEmpty(id))
      await _service.Create(dto);

    return RedirectToAction("Index");
  }
}
