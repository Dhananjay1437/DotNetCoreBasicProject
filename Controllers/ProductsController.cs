using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreBasicProject.Controllers
{
    public class ProductsController : Controller
    {
        [Route("products")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("search-products/{ProductID?}")]
        public IActionResult Search(int? ProductID)
        {
            ViewBag.ProductID = ProductID;
            return View();
        }

        [Route("order-product")]
        public IActionResult Order()
        {
            return View();
        }
    }
}
