using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new testEntities();
            var data = db.Products.ToList();
            return View(data );
        }

        public ActionResult Details(int Id)
        {
            var db = new testEntities();
            var data = (from c in db.Products where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        public ActionResult Edit(int Id)
        {
            var db = new testEntities();
            var data = (from c in db.Products where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
        [HttpPost]
        public ActionResult Edit(Product P)
        {
            var db = new testEntities();
            var data = (from c in db.Products where c.Id == P.Id select c).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(P);
            db.SaveChanges();
            return RedirectToAction("Index");
           

        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            var db = new testEntities();
            db.Products.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(Product P)
        {
            var db = new testEntities();
            var data = (from c in db.Products where c.Id == P.Id select c).FirstOrDefault();
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}