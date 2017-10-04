using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Controllers
{
    public class ErrorController : Controller
    {
        // GET: Error
        public ActionResult Index()
        {
            if (TempData["error"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Exception model = TempData["error"] as Exception;
            return View(model);
        }
    }
}