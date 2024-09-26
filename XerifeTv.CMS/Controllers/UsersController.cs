using Microsoft.AspNetCore.Mvc;
using XerifeTv.CMS.Models.User.Dtos.Request;
using XerifeTv.CMS.Models.User.Dtos.Response;
using XerifeTv.CMS.Models.User.Interfaces;

namespace XerifeTv.CMS.Controllers;

public class UsersController(IUserService _service) : Controller
{
  public async Task<IActionResult> Index()
  {
    var response = await _service.Get(1, 20);

    if (response.IsSuccess) 
      return View(response.Data?.Items);

    return View(Enumerable.Empty<GetUserRequestDto>());
  }

  public IActionResult Login()
  {
    return View();
  }

  public async Task<IActionResult> Register(RegisterUserRequestDto dto)
  {
    await _service.Register(dto);
    return RedirectToAction("Index");
  }
}