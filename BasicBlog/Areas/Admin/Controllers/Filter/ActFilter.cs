using BasicBlog.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Areas.Admin.Controllers.Filter
{
    public class ActFilter : FilterAttribute, IActionFilter
    {
        blogDBEntities db = new blogDBEntities();
        //actiondan sonra
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            db.Logs.Add(new Logs {
                userId = (filterContext.HttpContext.Session["login"] as user).id,
                actionName = filterContext.ActionDescriptor.ActionName,
                controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                time = DateTime.Now,
                alteration = "OnActionExecuted"


            });
           db.SaveChanges();
        }
        //Actiondan önce
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            db.Logs.Add(new Logs
            {
                userId = (filterContext.HttpContext.Session["login"] as user).id,
                actionName = filterContext.ActionDescriptor.ActionName,
                controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                time = DateTime.Now,
                alteration = "OnActionExecuting"
            });
            db.SaveChanges();
        }
    }
}