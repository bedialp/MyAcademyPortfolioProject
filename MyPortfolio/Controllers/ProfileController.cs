using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProfileController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Profile
        public ActionResult Index()
        {
            var values = db.TblFeatures.ToList();
            return View(values);
        }

        // PROFİL EKLEME İŞLEMLERİ
        public ActionResult AddProfile() { return View(); }
        [HttpPost]
        public ActionResult AddProfile(TblFeatures features)
        {
            db.TblFeatures.Add(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // PROFİL SİLME BUTONU İŞLEMİ
        public ActionResult DeleteProfile(int id)
        {
            var features = db.TblFeatures.Find(id);
            db.TblFeatures.Remove(features);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // PROFİL GÜNCELLEME BUTONU İŞLEMİ
        public ActionResult UpdateProfile(int id)
        {
            var features = db.TblFeatures.Find(id);
            return View(features);
        }
        [HttpPost]
        public ActionResult UpdateProfile(TblFeatures features)
        {
            var value = db.TblFeatures.Find(features.FetureId);
            value.NameSurname = features.NameSurname;
            value.Title = features.Title;
            value.ImageUrl = features.ImageUrl;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // AKTİF - PASİF BUTONU İŞLEMLERİ
        public ActionResult MakeActive(int id)
        {
            var value = db.TblFeatures.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            var value = db.TblFeatures.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}