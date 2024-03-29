using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            return View();
        }

        // FEATURE PARTIAL
        public PartialViewResult DefaultFeaturePartial()
        {
            var values = db.TblFeatures.ToList();

            return PartialView(values);
        }

        // ABOUT PARTIAL
        public PartialViewResult DefaultAboutPartial()
        {
            var values = db.TblAbouts.ToList();
            return PartialView(values);
        }

        // SEND MESSAGE PARTIAL
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult SendMessage(TblMessages messages)
        {
            db.TblMessages.Add(messages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SERVICE PARTIAL
        [HttpGet]
        public PartialViewResult DefaultServicePartial()
        {
            var values = db.TblServices.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        // SKILL PARTIAL
        public PartialViewResult DefaultSkillPartial()
        {
            var values = db.TblSkills.ToList();
            return PartialView(values);
        }

        // PROJECT PARTIAL
        public PartialViewResult DefaultProjectPartial()
        {
            var categories = db.TblCategories.ToList();
            ViewBag.categories = categories;

            var values = db.TblProjects.ToList();
            return PartialView(values);
        }

        // EXPERIENCE PARTIAL
        public PartialViewResult DefaultExperiencePartial()
        {
            var values = db.TblExperiences.ToList();
            return PartialView(values);
        }

        // TESTIMONIAL (REFERANSLARIM) PARTIAL
        public PartialViewResult DefaultTestimonialPartial()
        {
            var values = db.TblTestimonials.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        // TEAM (TAKIM ARKADASLARIM) PARTIAL
        public PartialViewResult DefaultTeamPartial()
        {
            var values = db.TblTeams.ToList();
            return PartialView(values);
        }
    }
}