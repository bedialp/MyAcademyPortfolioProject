using MyPortfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio.Controllers
{
    public class ContactController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        // GET: Contact
        public ActionResult Index()
        {
            var value = db.TblContacts.ToList();
            return View(value);
        }

        // İLETİŞİM BİLGİLERİNİ EKLEME İŞLEMİ 
        public ActionResult AddContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddContact(TblContacts contacts)
        {
            db.TblContacts.Add(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // İLETİŞİM BİLGİLERİNİ SİLME İŞLEMLERİ
        public ActionResult DeleteContact(int id)
        {
            var contacts = db.TblContacts.Find(id);

            db.TblContacts.Remove(contacts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        // İLETİŞİM BİLGİLERİNİ GÜNCELLEME İŞLEMLERİ
        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var contacts = db.TblContacts.Find(id);
            return View(contacts);
        }
        [HttpPost]
        public ActionResult UpdateContact(TblContacts contacts)
        {
            var value = db.TblContacts.Find(contacts.ContactId);
            value.NameSurname = contacts.NameSurname;
            value.Address = contacts.Address;
            value.Phone = contacts.Phone;
            value.Email = contacts.Email;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}