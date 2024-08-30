using Microsoft.AspNetCore.Mvc;

namespace XerifeTv.CMS.Controllers;

public class HomeController(ILogger<HomeController> _logger) : Controller
{
  public IActionResult Index()
  {
    _logger.Log(LogLevel.Information, "home index page");

    return View();
  }
}
