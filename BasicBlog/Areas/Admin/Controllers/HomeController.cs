using BasicBlog.Areas.Admin.Controllers.Filter;
using BasicBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers
{
    [AuthFilter]
    public class HomeController : BaseController
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.TotalArticle = db.article.Count();
            ViewBag.TotalProje = db.projes.Count();
            // ViewBag.TotalArticleView = db.article.Sum(x=>x)
            ViewBag.ArticleList = db.article.ToList();

            return View();
        }
    }
}