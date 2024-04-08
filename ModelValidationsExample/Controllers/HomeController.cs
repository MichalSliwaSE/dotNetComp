﻿using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers;

public class HomeController : Controller
{
    [Route("register")]
    public IActionResult Index(Person person)
    {
        if (!ModelState.IsValid)
        {
            List<string> errorsList = ModelState.Values.SelectMany(value =>
                value.Errors).Select(err => err.ErrorMessage).ToList();

            string errors = string.Join("\n", errorsList);
            return BadRequest(errors);
        }
        return Content($"{person}");
    }
}