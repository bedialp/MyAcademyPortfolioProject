using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class MessageController : Controller
    {

        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();

        // GELEN MESAJLARI GÖSTERİCEZ
        // GET: Message
        public ActionResult Index()
        {
            var values = db.TblMessages.ToList();
            return View(values);
        }

        // GELEN MESAJLARI SİLME İŞLEMİ
        public ActionResult DeleteMessage(int id)
        {
            var value = db.TblMessages.Find(id);
            db.TblMessages.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}