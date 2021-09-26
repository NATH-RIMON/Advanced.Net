using Pro.Models;
using Pro.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pro.Controllers
{
    public class ProductController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            Database db = new Database();
            var students = db.Products.Get();
            return View(students);
        }
        [HttpGet]
        public ActionResult Create()
        {
            Product p = new Product();
            return View(p);
        }
        [HttpPost]
        public ActionResult Create(Product p)
        {
            if (ModelState.IsValid)
            {
                Database db = new Database();
                db.Products.Create(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Database db = new Database();
            var s = db.Products.Get(id);
            return View(s);
        }

    }
}
