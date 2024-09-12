using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Series.Dtos.Request;
using XerifeTv.CMS.Models.Series.Dtos.Response;
using XerifeTv.CMS.Models.Series.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class SeriesController(ISeriesService _service) : Controller
{
  private const int limitResultsPage = 15;

  public async Task<IActionResult> Index(int? currentPage)
  {
    var result = await _service.Get(currentPage ?? 1, limitResultsPage);

    if (result.IsSuccess)
    {
      ViewBag.CurrentPage = result.Data?.CurrentPage;
      ViewBag.TotalPages = result.Data?.TotalPageCount ?? 1;
      ViewBag.HasNextPage = result.Data?.HasNext;
      ViewBag.HasPrevPage = result.Data?.HasPrevious;

      return View(result.Data?.Items);
    }

    return View(Enumerable.Empty<GetSeriesResponseDto>());
  }

  public async Task<IActionResult> Form(string? id)
  {
    if (id is not null)
    {
      var response = await _service.Get(id);
      if (response.IsSuccess) return View(response.Data);
    }

    return View();
  }

  public async Task<IActionResult> CreateForm(CreateSeriesRequestDto dto)
  {
    await _service.Create(dto);

    return RedirectToAction("Index");
  }

  public async Task<IActionResult> UpdateForm(UpdateSeriesRequestDto dto)
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
