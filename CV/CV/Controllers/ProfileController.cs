using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CV.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile
        public ActionResult Bio()
        {
            ViewBag.Name = "RIMON NATH";

            return View();
            
        }

        public ActionResult Education()
        {
            return View();
        }
        public ActionResult Project()
        {
          
            return View();
        }

        public ActionResult Reference()
        {
            ViewBag.Rname = "Tanvir Ahmed";
            ViewBag.Details = "Lecturer,Department of Computer Science, AIUB ";
            return View();
        }
    }
}