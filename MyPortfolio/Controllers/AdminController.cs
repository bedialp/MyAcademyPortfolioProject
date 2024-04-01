using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class AdminController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var values = db.TblAdmins.ToList();
            return View(values);
        }


        // ADMİN EKLEME İŞLEMİ
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View(); 
        }
        [HttpPost]
        public ActionResult AddAdmin(TblAdmin admin)
        {
            db.TblAdmins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ADMİN SİLME İŞLEMİ
        [HttpGet]
        public ActionResult DeleteAdmin(int id)
        {
            var values = db.TblAdmins.Find(id);
            db.TblAdmins.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // ADMİN GÜNCELLEME İŞLEMLERİ 
        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var values = db.TblAdmins.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(TblAdmin admin)
        {
            var values = db.TblAdmins.Find(admin.AdminId);
            values.UserName = admin.UserName;
            values.Password = admin.Password;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // AKTİF - PASİF BUTONU İŞLEMLERİ
        public ActionResult MakeActive(int id)
        {
            var value = db.TblAdmins.Find(id);
            value.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult MakePassive(int id)
        {
            var value = db.TblAdmins.Find(id);
            value.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}