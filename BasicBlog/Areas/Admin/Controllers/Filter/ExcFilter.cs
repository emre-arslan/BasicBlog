using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers.Filter
{
    public class ExcFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            blogDBEntities db = new blogDBEntities();
            int? userId=null;
            if (filterContext.HttpContext.Session["login"] != null)
            {
                userId = (filterContext.HttpContext.Session["login"] as user).id;
            }
            db.Logs.Add(new Logs
            {
                userId = userId,
                actionName = filterContext.RouteData.Values["action"].ToString(),
                controllerName = filterContext.RouteData.Values["controller"].ToString(),
                time = DateTime.Now,
                alteration ="Error :" + filterContext.Exception.Message


            });
            db.SaveChanges();
            filterContext.ExceptionHandled = true;
            filterContext.Controller.TempData["error"] = filterContext.Exception;
            filterContext.Result = new RedirectResult("~/Error/Index");

        }
    }
}