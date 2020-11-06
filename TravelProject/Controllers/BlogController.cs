using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Siniflar;

namespace TravelProject.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        Context ct = new Context();
        BlogYorum blogYorum = new BlogYorum();
        public ActionResult Index()
        {
            blogYorum.Deger1 = ct.Blogs.ToList();
            blogYorum.SonBloglar = ct.Blogs.OrderByDescending(x => x.ID).ToList();
            blogYorum.SonYorumlar = ct.Yorumlars.OrderByDescending(x => x.ID).ToList();

            return View(blogYorum);
        }

        public ActionResult BlogDetay(int ID)
        {
            // var getBlogWithID = ct.Blogs.Where(x => x.ID == ID).ToList();
            blogYorum.Deger1 = ct.Blogs.Where(x => x.ID == ID).ToList();
            blogYorum.Deger2 = ct.Yorumlars.Where(x => x.BlogId == ID).ToList();
            return View(blogYorum);
        }
        public PartialViewResult LastBlogs()
        {
            var GetBlogs = ct.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(GetBlogs);
        }
        public PartialViewResult LastBlogsIndex()
        {
            var GetBlogs = ct.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(GetBlogs);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }
        [HttpPost]
        public ActionResult YorumYap(Yorumlar yr)
        {
            
                ct.Yorumlars.Add(yr);
                ct.SaveChanges();
                return RedirectToAction("/BlogDetay/"+yr.BlogId);
            
          

            
        }


    }
}