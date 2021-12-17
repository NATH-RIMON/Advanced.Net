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
    public class TemplateController : Controller
    {

        // GET: Template
        public ActionResult Index()
        {
            /*
            var db = new ProjectEntities();
            var data = db.Templates.ToList();
            */

            var userId = (int)Session["UserId"];
            var db = new ProjectEntities();
            var data = from c in db.Templates where c.UserId == userId select c;


            return View(data);
        }
        public ActionResult Details(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Templates where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Templates where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost,AllowAnonymous]
        public string Fetch(int Id)
        {
            if (Id != 0)
            {

                var db = new ProjectEntities();
                var data = (from c in db.Templates where c.Id == Id select c).FirstOrDefault();
                return data.Message.Trim();
            }
            else return "";

        }

        [HttpPost]
        public ActionResult Edit(Template P)
        {
            P.Name.Trim();
            var db = new ProjectEntities();
            var data = (from c in db.Templates where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Template P)
        {
            Template temp = new Template()
            {
                Name = P.Name.Trim(),
                Message = P.Message,
                UserId = (int)Session["UserId"],
            };
            var db = new ProjectEntities();
            db.Templates.Add(temp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Template P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Templates where c.Id == P.Id select c).FirstOrDefault();
            db.Templates.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}