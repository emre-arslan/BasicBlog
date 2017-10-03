using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Controllers
{
    public class BaseController : Controller
    {
        // GET: Base
        public blogDBEntities db;


        public BaseController()
        {
            db = new blogDBEntities();
            //ViewBag.MetaDescription = db.siteSettings.FirstOrDefault().seoDescription;
            //ViewBag.MetaKeywords = db.siteSettings.FirstOrDefault().seoKeywords;
            //ViewBag.MetaTitle = db.siteSettings.FirstOrDefault().seoTitle;
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}