using ControllesExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;

namespace ControllesExample.Controllers;

public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public ContentResult Index()
    {
        return Content("<h1>Welcome to my page</h1> <h2>Hello from index</h2>",
            "text/html");
    }

    [Route("about")]
    public string About()
    {
        return "Hello from About";
    }

    [Route("contact/{mobile:regex(^\\d{{10}}$)}")]
    public string Contact()
    {
        return $"Hello from Contact";
    }

    [Route("person")]
    public JsonResult Person()
    {
        Person person = new Person()
        {
            Id = Guid.NewGuid(),
            FirstName = "Joe",
            LastName = "Mama",
            Age = 22,
        };
        return Json(person);
    }

    [Route("movie")]
    public VirtualFileResult MovieDownload()
    {
        return File("/js-logo-xs.png", "image/png");
    }
    
    [Route("picture")]
    public IActionResult RawPictureDownload()
    {
     byte[] bytes =    System.IO.File.ReadAllBytes(@"c:\aspnetcore\TemporarySolution\ControllesExample\wwwroot\js-logo-xs.png");
     return File(bytes, "image/png");
    }
    
    
    
}