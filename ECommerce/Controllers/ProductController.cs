using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    //MVC
    public class ProductController : Controller
    {
        //[HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            if (id > 0)
            {

                return View("card", id);
            }
            return RedirectToAction("index");
        }

        //[HttpGet]
        //public IActionResult Add() { 
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult Add(ProductDTO data) {

        //    ////save to database
        //    //return RedirectToAction("Index");
        //}
    }
}
