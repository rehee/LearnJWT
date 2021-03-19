using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearnJWT.Controllers
{
  public class HomeController : Controller
  {
    private readonly IAuthenticateService authenticateService;

    public HomeController(IAuthenticateService authenticateService)
    {
      this.authenticateService = authenticateService;
    }
    public IActionResult Index()
    {
      return Content("Home");
    }

    [HttpPost]
    public IActionResult Login([FromBody]LoginRequestDTO request)
    {
      authenticateService.IsAuthenticated(request, out var token);
      return Content(token);
    }
    [Authorize(Roles = "Admin")]
    public IActionResult TryAuth()
    {
      var request = this.Request;
      var user = this.User;
      return Content("123");
    }
  }
}