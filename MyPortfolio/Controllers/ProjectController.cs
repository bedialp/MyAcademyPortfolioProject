using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ProjectController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values = db.TblProjects.ToList();
            return View(values);
        }

        // EKLEME İŞLEMİ 
        [HttpGet]
        public ActionResult AddProject()
        {
            var categories = db.TblCategories.ToList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();
            ViewBag.category = categoryList;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects project)
        {
            db.TblProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GÜNCELLEME İŞLEMİ
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var categories = db.TblCategories.ToList();
            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString(),
                                                 }).ToList();
            ViewBag.category = categoryList;

            var value = db.TblProjects.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProject(TblProjects project)
        {
            var value = db.TblProjects.Find(project.ProjectId);
            value.ProjectName = project.ProjectName;
            value.ImageUrl = project.ImageUrl;
            value.GithubUrl = project.GithubUrl;
            value.CategoryId= project.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // SİLME İSLEMİ
        public ActionResult DeleteProject(int id)
        {
            var value = db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}