using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers.Filter
{
    public class ResFilter : FilterAttribute, IResultFilter
    {
        blogDBEntities db = new blogDBEntities();
        public void OnResultExecuted(ResultExecutedContext filterContext)
        {
            db.Logs.Add(new Logs
            {
                userId = (filterContext.HttpContext.Session["login"] as user).id,
                actionName = filterContext.RouteData.Values["action"].ToString(),
                controllerName = filterContext.RouteData.Values["controller"].ToString(),
                time = DateTime.Now,
                alteration = "OnResultExecuted"


            });
            db.SaveChanges();
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {
            db.Logs.Add(new Logs
            {
                userId = (filterContext.HttpContext.Session["login"] as user).id,
                actionName = filterContext.RouteData.Values["action"].ToString(),
                controllerName = filterContext.RouteData.Values["controller"].ToString(),
                time = DateTime.Now,
                alteration = "OnResultExecuting"


            });
            db.SaveChanges();
        }
    }
}