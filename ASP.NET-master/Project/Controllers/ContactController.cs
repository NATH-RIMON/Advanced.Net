using Project.Auth;
using Project.Models.Entities;
using Project.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Project.Controllers
{
    [BasicAuthFilter, UserAccess]
    public class ContactController : Controller
    {
        // GET: Contract
        public ActionResult Index()
        {
            var db = new ProjectEntities();
            var data = db.Contacts.ToList();
            return View(data);




        }
        public ActionResult Details(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Contacts where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Contacts where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Contact P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Contacts where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult Create()
        {
            ContactModel cm = new ContactModel();

            if (Session["UserId"] != null)
            {

                var userId = (int)Session["UserId"];
                var db = new ProjectEntities();
                var data = (from c in db.Groups where c.UserId == userId select c).ToList();
                //return View(data);
                cm.Groups = data;

            }
            return View(cm);
        }
        [HttpPost]
        public ActionResult Create(ContactModel cm)
        {

            Contact c = new Contact()
            {
                Name = cm.Name,
                Number = cm.Number,
                GroupId = cm.GroupId,
            };




            var db = new ProjectEntities();
            db.Contacts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");

            

            //return View();
        }

        public ActionResult Delete(SenderNumber P)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Contacts where c.Id == P.Id select c).FirstOrDefault();
            db.Contacts.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}