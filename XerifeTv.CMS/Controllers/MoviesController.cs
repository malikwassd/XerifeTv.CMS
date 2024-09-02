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

  public async Task<IActionResult> FormPost(CreateMovieRequestDto createDto)
  {
    var id = Request.Form["id"];

    if (string.IsNullOrEmpty(id))
    {
      await _service.Create(createDto);
    }
    else 
    {
      var updateDto = new UpdateMovieRequestDto
      {
        Id = id!,
        Title = createDto.Title,
        Synopsis = createDto.Synopsis,
        Category = createDto.Category,
        BannerUrl = createDto.BannerUrl,
        PosterUrl = createDto.PosterUrl,
        ParentalRating = createDto.ParentalRating,
        ReleaseYear = createDto.ReleaseYear,
        Review = createDto.Review,
        VideoDuration = createDto.VideoDuration,
        VideoStreamFormat = createDto.VideoStreamFormat,
        VideoUrl = createDto.VideoUrl
      };

      await _service.Update(updateDto);
    }
 
    return RedirectToAction("Index");
  }

  public async Task<IActionResult> Delete(string? id)
  {
    if (id is not null) await _service.Delete(id);

    return RedirectToAction("Index");
  }
}
