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
    public class ProfileController : BaseController
    {
        // GET: Admin/Profile
        public ActionResult Index()
        {
            var query = db.user.FirstOrDefault();
            ViewBag.Projes = db.projes.ToList();
            return View(query);
        }
    }
}