using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models.VM;
using System.ComponentModel.DataAnnotations;
using Project.Models.Entities;
using Project.Service;
using Project.Auth;

namespace Project.Controllers
{
    [BasicAuthFilter, UserAccess]

    public class SenderController : Controller
    {
        // GET: Sender
        SenderModel sm = new SenderModel();



        public void updateData()
        {
            //var userId = 5;
            var userId = (int)Session["UserId"];
            var db = new ProjectEntities();
            var data = db.SenderNumbers.ToList();
            var dataTemplates = (from c in db.Templates where c.UserId == userId select c).ToList();

            this.sm.SenderNumbers = data;
            this.sm.Templates = dataTemplates;
        }


        public void InsertMessage(Message m)
        {
            var db = new ProjectEntities();
            db.Messages.Add(m);
            db.SaveChanges();
        }
        public ActionResult Index()
        {
            this.updateData();
            return View(sm);


            //return View();
        }


        // GET: Sender/Create


        // POST: Sender/Create
        [HttpPost]
        public ActionResult Index(SenderModel um)
        {
            if (ModelState.IsValid)
            {
                this.updateData();
                int userId = (int)Session["UserId"];
                //int userId = 5;

                SMSProcess smsProcess = new SMSProcess();

                int status = smsProcess.Process(userId, um);

                if (status == 1)
                {
                    ViewBag.SuccessMessage = "Message Send";
                    //return RedirectToAction("Home\Index");
                    return View(sm);
                }
                else if (status == 2)
                {
                    ViewBag.ErrorMessage = "Message Send Failed";
                    return View(sm);

                }
                else if (status == 3)
                {
                    ViewBag.ErrorMessage = "Balance low";

                    return View(sm);
                }


                ViewBag.ErrorMessage = "Something Went wrong";
                return View(sm);


            }

            ViewBag.ErrorMessage = "Something Went wrong";
            return View(sm);

        }
    }
}
