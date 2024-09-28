using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.Dashboard.Dtos.Response;
using XerifeTv.CMS.Models.Dashboard.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class HomeController(IDashboardService _service) : Controller
{
  public async Task<IActionResult> Index()
  {
    if (User.Identity is null) 
      return RedirectToAction("SignIn", "Users");

    if (!User.Identity.IsAuthenticated) 
      return RedirectToAction("SignIn", "Users");

    var response = await _service.Get();
    if (response.IsSuccess) return View(response.Data);

    return View(new GetDashboardDataRequestDto(0, 0, 0));
  }
}