using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SocialMediaController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: SocialMedia
        public ActionResult Index()
        {
            var values = db.TblSocialMedias.ToList();
            return View(values);
        }

        // SOSYAL MEDYA EKLEME İŞLEMİ
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedias socials)
        {
            db.TblSocialMedias.Add(socials);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SOSYAL MEDYA SİLME İŞLEMİ
        public ActionResult DeleteSocialMedia(int id)
        {
            var social = db.TblSocialMedias.Find(id);

            db.TblSocialMedias.Remove(social);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SOSYAL MEDYA GÜNCELLEME İŞLEMİ
        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            var social= db.TblSocialMedias.Find(id);
            return View(social); ;
        }

        [HttpPost]
        public ActionResult UpdateSocialMedia(TblSocialMedias social)
        {
            var value = db.TblSocialMedias.Find(social.SocialMediaId);
            value.SocialMediaName = social.SocialMediaName;
            value.Url = social.Url;
            value.Icon = social.Icon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}