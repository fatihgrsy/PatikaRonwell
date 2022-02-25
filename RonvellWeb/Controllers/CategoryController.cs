using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RonvellWeb.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {

            var data = GetCategory();
            ViewBag.data = data;
            return View();
        }

        public JsonResult GetCategory()
        {
            return Json("");
        }
    }
}