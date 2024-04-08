using IActionResultExample.Model;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
    [Route("bookstore/{bookid?}/{isLoggedIn?}")]
    public IActionResult Index(int? bookid, [FromRoute] bool? isLoggedIn, Book book)
    {
        //Book id should be applied and not empty
        if (bookid.HasValue == false)
        {
            return BadRequest("Book id is not supplied or empty");
        }

        //Book id cannot be empty
        if (bookid is <= 0 or > 1000)
        {
            return BadRequest("Book id cannot be 0 or less and bigger than 1000");
        }

        // isLoggedin should be true
        if (isLoggedIn == false)
        {
            return StatusCode(401, "User has to be logged in.");
        }
        // return RedirectToAction("Books", "Store", new { id = bookId });

        // return  RedirectToActionPermanent("Books", "Store", new { id = bookId});

        // return LocalRedirect($"/store/books/{bookId}");
        return Content($"Book id : {book}", "text/plain");
    }
}