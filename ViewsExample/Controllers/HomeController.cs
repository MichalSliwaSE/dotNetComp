using Microsoft.AspNetCore.Mvc;

namespace ViewsExample.Controllers;

public class HomeController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}