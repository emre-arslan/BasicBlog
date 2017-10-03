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
    public class TagController : BaseController
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            var query = db.tag.ToList();
            return View(query);
        }
        public ActionResult tagAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult tagAdd(tag Model)
        {
            db.tag.Add(Model);
            db.SaveChanges();
            return RedirectToAction("Index", "Tag");
        }
        public ActionResult tagUpdate(int id = 0)
        {
            var query = db.tag.FirstOrDefault(x => x.id == id);
            return View(query);
        }
        [HttpPost]
        public ActionResult tagUpdate(tag Model)
        {
            var query = db.tag.FirstOrDefault(x => x.id == Model.id);
            query.definition = Model.definition;
            db.SaveChanges();

            return RedirectToAction("Index", "Tag");

        }
        public ActionResult tagDelete(int id = 0)
        {
            var query = db.tag.FirstOrDefault(x => x.id == id);
            db.tag.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "Tag");

        }
    }
}