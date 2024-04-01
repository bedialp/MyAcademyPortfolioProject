using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class TestimonialController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Testimonial
        public ActionResult Index()
        {
            var values = db.TblTestimonials.ToList();
            return View(values);
        }


        // REFERANS EKLEME İŞLEMİ 
        [HttpGet]
        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(TblTestimonials referans)
        {
            db.TblTestimonials.Add(referans);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // REFERANS SİLME İŞLEMİ
        public ActionResult DeleteTestimonial(int id)
        {
            var about = db.TblTestimonials.Find(id);

            db.TblTestimonials.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //REFERANS GÜNCELLEME İŞLEMİ
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var about = db.TblTestimonials.Find(id);
            return View(about); ;
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(TblTestimonials referans)
        {
            var value = db.TblTestimonials.Find(referans.TestimonialId);
            value.ImageUrl = referans.ImageUrl;
            value.Comment = referans.Comment;
            value.NameSurname = referans.NameSurname;
            value.Title = referans.Title;
            value.Status = referans.Status;
            value.CommentDate = referans.CommentDate;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // AKTİF - PASİF BUTONU İŞLEMLERİ
        public ActionResult MakeActive(int id)
        {
            var value = db.TblTestimonials.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            var value = db.TblTestimonials.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}