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
            ViewBag.Last5Article = db.article.OrderByDescending(x => x.id).Take(5).ToList();
            ViewBag.CommentCount = db.article.Count(x => x.comment.Any(y => y.articleId == x.id));
            ViewBag.Popular = db.article.Take(5).OrderBy(x => x.articleView);
            ViewBag.CategoryList = db.category.OrderBy(x => x.catOrder).Where(x => x.mainMenu == true);
            return View();
        }
        public PartialViewResult Popular()
        {
            var query = db.article.Take(5).OrderBy(x => x.articleView).ToList() ;
            return PartialView("_PopularPartial", query);
        }
        public PartialViewResult Recent()
        {
            var query = db.article.Take(5).OrderBy(x => x.articleView).ToList();
            return PartialView("_PopularPartial", query);
        }
        public PartialViewResult Reviews()
        {
            var query = db.comment.Take(5).OrderByDescending(x => x.date).ToList();
            return PartialView("_ReviewsPartial", query);
        }
    }
}