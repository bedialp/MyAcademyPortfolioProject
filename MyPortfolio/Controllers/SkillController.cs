using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class SkillController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Skill
        public ActionResult Index()
        {
            var values = db.TblSkills.ToList();
            return View(values);
        }

        // EKLEME İŞLEMİ
        public ActionResult AddSkill()
        {
            var skills = db.TblSkills.ToList();
            List<SelectListItem> skillList = (from x in skills
                                              select new SelectListItem
                                              {
                                                  Text = x.SkillName,
                                                  Value = x.SkillId.ToString(),
                                              }).ToList();
            ViewBag.Skills = skillList;

            return View();
        }

        [HttpPost]
        public ActionResult AddSkill(TblSkills skills)
        {
            db.TblSkills.Add(skills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GÜNCELLEME İŞLEMİ
        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var skill = db.TblSkills.ToList();
            List<SelectListItem> skillList = (from x in skill
                                              select new SelectListItem
                                              {
                                                  Text = x.SkillName,
                                                  Value = x.SkillId.ToString(),
                                              }).ToList();
            ViewBag.Skills = skillList;
            var value = db.TblSkills.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(TblSkills skill)
        {
            var value = db.TblSkills.Find(skill.SkillId);
            value.SkillName = skill.SkillName;
            value.Value = skill.Value;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SİLME İŞLEMİ
        public ActionResult DeleteSkill(int id)
        {
            var value = db.TblSkills.Find(id);
            db.TblSkills.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}