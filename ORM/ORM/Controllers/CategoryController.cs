using ORM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ORM.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var db = new testEntities();
            var data = db.Categories.ToList();
            return View(data);
           
        }
        public ActionResult Details(int Id)
        {
            var db = new testEntities();
            var data = (from c in db.Categories where c.Id == Id select c).FirstOrDefault();
            return View(data);

        }
    }
}