using Project.Auth;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [AdminAccess, BasicAuthFilter]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            var db = new ProjectEntities();
            var data = db.Users.ToList();
            return View(data);
        }
        public ActionResult Details(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Users where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Users where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(User P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Users where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View(new User());
        }
        [HttpPost]
        public ActionResult Create(User p)
        {
            var db = new ProjectEntities();
            db.Users.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(User P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Users where c.Id == P.Id select c).FirstOrDefault();
            db.Users.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}