using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using TravelProject.Models.Siniflar;

namespace TravelProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context ct = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var GetBlogList = ct.Blogs.ToList();
            return View(GetBlogList);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();

        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            ct.Blogs.Add(p);
            ct.SaveChanges();
            return RedirectToAction("/Admin/Index");
        }
        public ActionResult BlogSil(int id)
        {
            var del = ct.Blogs.Find(id);
            ct.Blogs.Remove(del);
            ct.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var b1 = ct.Blogs.Find(id);
            return View("BlogGetir", b1);

        }
        [HttpPost]
        public ActionResult BlogGuncelle(Blog b)
        {
            var blg = ct.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Baslik = b.Baslik;
            blg.Tarih = b.Tarih;
            blg.FotoUrl = b.FotoUrl;
            ct.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Commentlist()
        {
            var getir = ct.Yorumlars.ToList();
            return View(getir);
        }
        public ActionResult YorumSil(int id)
        {
            Yorumlar yorum = ct.Yorumlars.Find(id);

            ct.Yorumlars.Remove(yorum);
            ct.SaveChanges();
            return RedirectToAction("Commentlist");
        }
        [HttpGet]
        public ActionResult YorumEdit(int id=0)
        {
            if (id >= 0)
            {
                var b1 = ct.Yorumlars.Find(id);
                if (b1==null){return HttpNotFound("Not Found");}else{return View("YorumEdit", b1);}             
            }
            else
            {
                return View();

            }


        }
        [HttpPost]
        public ActionResult YorumEdit(Yorumlar yr)
        {
            var yrm = ct.Yorumlars.Find(yr.ID);
            yrm.EMail = yr.EMail;
            yrm.Yorum = yr.Yorum;
            yrm.KullaniciAdi = yr.KullaniciAdi;
            ct.SaveChanges();
            return RedirectToAction("Commentlist");

        }


    }
}