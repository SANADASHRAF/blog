using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using plog_project.Models;
namespace plog_project.Controllers
{
    public class newsController : Controller
    {
        blogcontect db = new blogcontect();
        public ActionResult add()
        {
            if (Session["userid"] == null) return RedirectToAction("login", "admeen");
            //drop down list
            SelectList li = new SelectList(db.catalogs.ToList(), "id", "nam");
            ViewBag.catigory = li;
             
            return View();
        }
        [HttpPost]
        public ActionResult add ( news n,HttpPostedFileBase imag)
        {
            imag.SaveAs(Server.MapPath($"~/attach/attachnews/ { imag.FileName}"));
            n.photo = $"/attach/attachnews/ { imag.FileName}";
            n.user_id = (int)Session["userid"];
            n.datetime = DateTime.Now;
           
                db.news.Add(n);
                db.SaveChanges();
                return RedirectToAction("MyNews");
            
           
        }

        public ActionResult MyNews()
        {
            if ( Session["userid"] == null) return RedirectToAction("login", "admeen");
            int user = (int)Session["userid"];
            List<news> li = db.news.Where(n => n.user_id == user).ToList();
            return View(li);
        }
        public ActionResult delete(int id)
        {
            news s = db.news.Where(n => n.id == id).SingleOrDefault();
            db.news.Remove(s);
            db.SaveChanges();
            return RedirectToAction("MyNews");
        }
        public ActionResult modify( int id)
        {
            List<news> li = db.news.ToList();
            news s = db.news.Where(n => n.id == id).SingleOrDefault();
           
            return View(s);
        }
        [HttpPost]
        public ActionResult modify(news f)
        {
            db.Entry(f).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("MyNews");
        }
        public ActionResult readmore(int s)
        {
            news e = db.news.Where(n => n.id == s).SingleOrDefault();
            return View(e);
        }
        public ActionResult allnews()
        {
            List<news> li = db.news.ToList();
            return View(li);
        }
        
    }
}
