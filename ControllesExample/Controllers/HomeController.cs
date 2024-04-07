using Microsoft.AspNetCore.Mvc;

namespace ControllesExample.Controllers;

public class HomeController : ControllerBase
{
    [Route("home")]
    [Route("/")]
    public string Index()
    {
        return "Hello from home";
    }
    [Route("about")]
    
    public string About()
    {
        return "Hello from About";
    }
    [Route("contact")]
  
    public string Contact()
    {
        return "Hello from Contact";
    }
}