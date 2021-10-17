using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestORM.Models;

namespace TestORM.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            var db = new testEntities();
            var data = db.Products.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
       public ActionResult Create(Product p)
        {
            var d = new testEntities();
            d.Products.Add(p);
            d.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}