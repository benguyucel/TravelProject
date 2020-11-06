using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Siniflar;

namespace TravelProject.Controllers
{
    public class DefaultController : Controller
    {
        Context context = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var getBlogImages = context.Blogs.OrderByDescending(x=>x.ID).Take(4).ToList();
            return View(getBlogImages);
        }
        public ActionResult About()
        {
            return View();
        }
        public PartialViewResult Partial1()
        {
            var getLast3Blogs = context.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(getLast3Blogs);
        }
        public PartialViewResult Partial2()
        {
            return PartialView();
        }
    }
}