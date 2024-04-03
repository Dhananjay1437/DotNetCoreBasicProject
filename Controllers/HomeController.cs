using Microsoft.AspNetCore.Mvc;
using System;
using DotNetCoreBasicProject.Models;

namespace DotNetCoreBasicProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        
        //Example JSON: { "PersonName": "William", "Email": "william@example.com", "Phone": "123456", "Password": "william123", "ConfirmPassword": "william123","Age":22 }
       
        //[ModelBinder(BinderType = typeof(PersonModelBinder))]   //add this in function if you want to use custom modal binder
      
        // public IActionResult Index([Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]  Person person)   //only selected field will get from user

        // public IActionResult Index(Person person)   //use for form-data,x-www-urlincoding or query binding if you want
       
        public IActionResult Register([FromBody] Person person, [FromHeader(Name = "User-Agent")] string UserAgent)
        {
            if (!ModelState.IsValid)
            {
                //get error messages from model state
                string errors = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            return Content($"{person},{UserAgent}");
        }


       
        [Route("/Home")]
        public IActionResult Index()
        {
            //Views/Home/Index.cshtml
            //return View("abc"); //abc.cshtml
            //return new ViewResult() { ViewName = "abc" };
            return View();
        }
        [Route("products/all")]
        public IActionResult All()
        {
            return View();
            //Views/Products/All.cshtml
            //Views/Shared/All.cshtml
        }

    }
}