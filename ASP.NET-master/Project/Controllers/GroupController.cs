using Project.Auth;
using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [BasicAuthFilter, UserAccess]
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            var userId = (int)Session["UserId"];
            var db = new ProjectEntities();
            var data = from c in db.Groups where c.UserId ==userId select c;
            //var data = db.Groups.ToList();
            return View(data);
        }
        public ActionResult Details(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Groups where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Groups where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Group P)
        {
            P.Name.Trim();
            var db = new ProjectEntities();
            var data = (from c in db.Groups where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Group P)
        {

            Group group = new Group()
            {
                Name = P.Name.Trim(),
                UserId = (int)Session["UserId"],
            };
            var db = new ProjectEntities();
            db.Groups.Add(group);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Group P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Groups where c.Id == P.Id select c).FirstOrDefault();
            db.Groups.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}