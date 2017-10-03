using BasicBlog.Areas.Admin.Controllers.Filter;
using BasicBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers
{   [AuthFilter]
    public class ArticleController : BaseController
    {
        // GET: Admin/Article
        public ActionResult Index()
        {
            var query = db.article.ToList();
            return View(query);
        }
        public ActionResult Create()
        {
            //List<SelectListItem> CatList = (from k in db.category
            //                                select new SelectListItem
            //                                {
            //                                    Text = k.definition,
            //                                    Value = k.id.ToString()
            //                                       }).ToList();
            //ViewBag.CatList = CatList;
            ViewBag.CatList = new SelectList(db.category, "id", "definition");
            return View();
        }
        [HttpPost]
        public ActionResult Create(article Model)
        {
            db.article.Add(Model);
            db.SaveChanges();
            return RedirectToAction("Index", "Article");

        }
        public ActionResult Update(int id = 0)
        {
            if (id != 0)
            {
                var query = db.article.FirstOrDefault(x => x.id == id);
                ViewBag.CatList = new SelectList(db.category, "id", "definition", query.categoryId);
                return View(query);
            }
            else
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult Update(article Model)
        {
            if (Model != null)
            {
                var query = db.article.FirstOrDefault(x => x.id == Model.id);
                query.categoryId = Model.categoryId;
                query.contents = Model.contents;
                query.seoLink = Model.seoLink;
                query.thumbnail = Model.thumbnail;
                query.title = Model.title;
                db.SaveChanges();
                return RedirectToAction("Index", "Article");

            }
            else
            {

            }
            return View();
        }
        public ActionResult Delete(int id = 0)
        {
            if (id != 0)
            {
                var query = db.article.FirstOrDefault(x => x.id == id);
                db.article.Remove(query);
                db.SaveChanges();
                return RedirectToAction("Index", "Article");
            }
            else
            {

            }
            return View();
        }
        public ActionResult Active(int id = 0)
        {
            var query = db.article.FirstOrDefault(x => x.id == id);
            query.status = true;
            db.SaveChanges();
            return RedirectToAction("Index", "Article");
        }
        public ActionResult Deactivate(int id = 0)
        {
            var query = db.article.FirstOrDefault(x => x.id == id);
            query.status = false;
            db.SaveChanges();
            return RedirectToAction("Index", "Article");
        }
    }
}