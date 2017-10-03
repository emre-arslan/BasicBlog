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
    public class ProjeController : BaseController
    {
        // GET: Admin/Proje
        public ActionResult Index()
        {
            var query = db.projes.ToList();

            return View(query);
        }
        public ActionResult ProjeAdd()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ProjeAdd(projes Model)
        {
            if (Model != null)
            {
                db.projes.Add(Model);
                db.SaveChanges();
            }
            else
            {

            }
            return RedirectToAction("Index", "Proje");
        }
        public ActionResult ProjeUpdate(int id = 0)
        {
            if (id != 0)
            {
                var query = db.projes.FirstOrDefault(x => x.id == id);
                return View(query);
            }
            else
            {

            }
            return View();
        }
        [HttpPost]
        public ActionResult ProjeUpdate(projes Model)
        {
            if (Model != null)
            {
                var query = db.projes.FirstOrDefault(x => x.id == Model.id);
                query.language = Model.language;
                query.linkedinLink = Model.linkedinLink;
                query.productLink = Model.productLink;
                query.projeName = Model.projeName;
                query.seoLink = Model.seoLink;
                query.thumbnail = Model.thumbnail;
                query.githunLink = Model.githunLink;
                query.contents = Model.contents;
                db.SaveChanges();
                return RedirectToAction("Index", "Proje");

            }
            else
            {

            }
            return View();
        }
        public ActionResult ProjeDelete(int id = 0)
        {
            if (id != 0)
            {
                var query = db.projes.FirstOrDefault(x => x.id == id);
                db.projes.Remove(query);
                db.SaveChanges();
                return RedirectToAction("Index", "Proje");

            }
            else
            {

            }
            return View();
        }
    }
}