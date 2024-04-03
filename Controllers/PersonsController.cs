using Microsoft.AspNetCore.Mvc;
using System;
using DotNetCoreBasicProject.Models;

namespace DotNetCoreBasicProject.Controllers
{
    public class PersonsController : Controller
    {
       
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["appTitle"] = "Asp.Net Core Demo App";

            List<Person> people = new List<Person>()
      {
          new Person() { PersonName = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
          new Person() { PersonName = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
          new Person() { PersonName = "Susan", DateOfBirth = DateTime.Parse("2008-07-12"), PersonGender = Gender.Other}
      };
           /* ViewData["people"] = people;
            ViewBag.People = people;
           return View("about");*/

          //  return View("Persons", people);       //another way to bind modal to view
            return View("Index", people);       //if it sending to Index cshtml
        }
        [Route("person/{name}")]
        public IActionResult PersonDetails(string? name)
        {
            if (name == null)
                return Content("Person name can't be null");

            List<Person> people = new List<Person>()
      {
          new Person() { PersonName = "John", DateOfBirth = DateTime.Parse("2000-05-06"), PersonGender = Gender.Male},
          new Person() { PersonName = "Linda", DateOfBirth = DateTime.Parse("2005-01-09"), PersonGender = Gender.Female},
          new Person() { PersonName = "Susan", DateOfBirth = null, PersonGender = Gender.Other}
      };
            Person? matchingPerson = people.Where(temp => temp.PersonName == name).FirstOrDefault();
            return View(matchingPerson);  //Views/Persons/PersonDetails.cshtml
        }
        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person() { PersonName = "Sara", PersonGender = Gender.Female, DateOfBirth = Convert.ToDateTime("2004-07-01") };

            Product product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };

            PersonAndProductWrapperModel personAndProductWrapperModel = new PersonAndProductWrapperModel() { PersonData = person, ProductData = product };
            return View(personAndProductWrapperModel);
        }
        [Route("/all-products")]
        public IActionResult All()
        {
            return View();
          
        }
    }
  
}