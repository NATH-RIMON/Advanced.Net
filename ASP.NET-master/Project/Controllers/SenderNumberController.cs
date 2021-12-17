using Project.Auth;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [AdminAccess,BasicAuthFilter]


    public class SenderNumberController : Controller
    {

        // GET: SenderNumber
        public ActionResult Index()
        {
            var db = new ProjectEntities();
            var data = db.SenderNumbers.ToList();
            return View(data);
        }
        public ActionResult Details(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.SenderNumbers where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.SenderNumbers where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(SenderNumber P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.SenderNumbers where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SenderNumber P)
        {
            var db = new ProjectEntities();
            db.SenderNumbers.Add(P);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(SenderNumber P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.SenderNumbers where c.Id == P.Id select c).FirstOrDefault();
            db.SenderNumbers.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}