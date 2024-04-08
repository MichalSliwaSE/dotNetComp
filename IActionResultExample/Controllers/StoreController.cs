using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class StoreController : Controller
{
    [Route("store/books/{id}")]
    public IActionResult Books()
    {
        int id = Convert.ToInt16(Request.RouteValues["id"]);
        return File("/js-logo-xs.png", "image/png");
    }
}
