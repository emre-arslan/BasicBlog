using BasicBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View(new user());
        }
        [HttpPost]
        public ActionResult Index(user model)
        {
            var query = db.user.FirstOrDefault(x => x.userName == model.userName && x.password == model.password && x.status == true);
            if (query == null)
            {
                return View(model);
            }
            else
            {
                Session["login"] = query;
                return RedirectToAction("Index", "Admin/Home");
            }

        }
    }
}