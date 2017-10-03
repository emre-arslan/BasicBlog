using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Controllers
{
    public class FooterController : BaseController
    {
        // GET: Footer
        public PartialViewResult Index()
        {
            return PartialView("_FooterPartial");
        }
    }
}