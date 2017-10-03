using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Last5Article = db.article.OrderByDescending(x=>x.id).Take(5).ToList();
            return View();
        }
    }
}