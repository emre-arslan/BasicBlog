using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicBlog.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        
       
        public ActionResult Index(int id=0)
        {
            if (id ==0)
            {

            }
            else
            {
                var query = db.article.Where(x => x.categoryId == id).ToList();
                return View(query);

            }
            return View();
        }
        public ActionResult ArticleView(int id=0)
        {
            return View();
        }
    }
}