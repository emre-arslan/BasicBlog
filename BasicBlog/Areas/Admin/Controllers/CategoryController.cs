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
    public class CategoryController : BaseController
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var query = db.category.ToList();
            return View(query);
        }
        [HttpGet]
        public ActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(category Model)
        {
            if (Model != null)
            {
                db.category.Add(Model);
                db.SaveChanges();
            }
            else
            {

            }

            return View();
        }

        public ActionResult CategoryUpdate(int id = 0)
        {
            if (id != 0)
            {
                var query = db.category.SingleOrDefault(x => x.id == id);
                return View(query);
            }
            else
            {
                return RedirectToAction("Index", "Category");
            }

        }
        [HttpPost]
        public ActionResult CategoryUpdate(category Model)
        {
            var query = db.category.FirstOrDefault(x => x.id == Model.id);
            query.definition = Model.definition;
            query.mainMenu = Model.mainMenu;
            query.catOrder = Model.catOrder;
            query.seoLink = Model.seoLink;
            query.image = Model.image;
            db.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        public ActionResult CategoryDelete(int id = 0)
        {
            if (id != 0)
            {
                var query = db.category.FirstOrDefault(x => x.id == id);
                db.category.Remove(query);
                db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            else
            {

            }
            return RedirectToAction("Index", "Category");
        }
    }
}