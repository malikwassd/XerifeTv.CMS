using Microsoft.AspNetCore.Mvc;

namespace XerifeTv.CMS.Controllers;

public class MoviesController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
