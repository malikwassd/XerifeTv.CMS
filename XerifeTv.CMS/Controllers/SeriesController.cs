using Microsoft.AspNetCore.Mvc;

namespace XerifeTv.CMS.Controllers;

public class SeriesController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
