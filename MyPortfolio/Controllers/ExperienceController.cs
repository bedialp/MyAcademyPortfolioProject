using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ExperienceController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Experience
        public ActionResult Index()
        {
            var value = db.TblExperiences.ToList();
            return View(value);
        }


        // DENEYİMLERİ EKLEME İŞLEMİ 
        [HttpGet]
        public ActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddExperience(TblExperiences experiences)
        {
            db.TblExperiences.Add(experiences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DENEYİMLERİ SİLME İŞLEMLERİ
        public ActionResult DeleteExperience(int id)
        {
            var experiences = db.TblExperiences.Find(id);

            db.TblExperiences.Remove(experiences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // DENEYİMLERİ GÜNCELLEME İŞLEMLERİ
        [HttpGet]
        public ActionResult UpdateExperience(int id)
        {
            var experiences = db.TblExperiences.Find(id);
            return View(experiences); 
        }
        [HttpPost]
        public ActionResult UpdateExperience(TblExperiences experiences)
        {
            var value = db.TblExperiences.Find(experiences.ExperienceId);
            value.StartYear = experiences.StartYear;
            value.EndYear = experiences.EndYear;
            value.Title = experiences.Title;
            value.Description = experiences.Description;
            value.Company = experiences.Company;
            value.Location = experiences.Location;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}