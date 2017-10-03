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
    public class SiteSettingsController : BaseController
    {
        // GET: Admin/SiteSettings
        public ActionResult Index()
        {
            var query = db.siteSettings.SingleOrDefault();

            if (query == null)
            {
                return RedirectToAction("Create", "SiteSettings");
            }
            else
            {
                return View(query);
            }
        }
        public ActionResult Create()
        {
            var query = db.siteSettings.FirstOrDefault();
            if (query != null)
            {
                db.siteSettings.Remove(query);
                db.SaveChanges();
            }
            return View();
        }
        [HttpPost]
        public ActionResult Create(siteSettings Model)
        {
            db.siteSettings.Add(Model);
            db.SaveChanges();

            return RedirectToAction("Index", "SiteSettings");

        }
        public ActionResult Update(int id = 0)
        {
            var query = db.siteSettings.FirstOrDefault(x => x.id == id);
            return View(query);
        }
        [HttpPost]
        public ActionResult Update(siteSettings Model)
        {
            var query = db.siteSettings.FirstOrDefault(x => x.id == Model.id);
            query.facebook = Model.facebook;
            query.googlemapsLink = Model.googlemapsLink;
            query.googleplus = Model.googleplus;
            query.linkedin = Model.linkedin;
            query.mail = Model.mail;
            query.seoAbstract = Model.seoAbstract;
            query.seoAuthor = Model.seoAuthor;
            query.seoCopyright = Model.seoCopyright;
            query.seoDescription = Model.seoDescription;
            query.seoDesigner = Model.seoDesigner;
            query.seoKeywords = Model.seoKeywords;
            query.seoTitle = Model.seoTitle;
            query.siteName = Model.siteName;
            query.twitter = Model.twitter;
            db.SaveChanges();
            return RedirectToAction("Index", "SiteSettings");

        }
        public ActionResult Delete(int id = 0)
        {
            var query = db.siteSettings.FirstOrDefault(x => x.id == id);
            db.siteSettings.Remove(query);
            db.SaveChanges();
            return RedirectToAction("Index", "SiteSettings");

        }
    }
}