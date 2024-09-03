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
