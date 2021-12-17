using Project.Auth;
using Project.Models.Entities;
using Project.Models.VM;
using Project.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Controllers
{
    [BasicAuthFilter, UserAccess]
    public class BulkSenderController : Controller
    {
        // GET: BulkSender
        readonly BulkSenderModel bsm = new BulkSenderModel();


        public ActionResult Index()
        {
            //var userId = 5;
            if (Session["UserId"] != null)
            {
                this.UpdateData();

            }
            return View(bsm);
        }

        public void UpdateData()
        {
            var userId = (int)Session["UserId"];
            var db = new ProjectEntities();
            var senderNumbersData = db.SenderNumbers.ToList();
            var dataTemplates = (from c in db.Templates where c.UserId == userId select c).ToList();
            var groupsData = (from c in db.Groups where c.UserId == userId select c).ToList();
            this.bsm.SenderNumbers = senderNumbersData;
            this.bsm.Templates = dataTemplates;
            this.bsm.Groups = groupsData;
        }

        [HttpPost]
        public ActionResult Index(BulkSenderModel bm)
        {
            if (Session["UserId"] != null)
            {
                var userId = (int)Session["UserId"];
                var db = new ProjectEntities();

                var dataContacts = (from c in db.Contacts where c.GroupId == bm.GroupId select c).ToList();

                int failCount = 0;
                int sucessCount = 0;

                string tempMsg = null;

                foreach (var item in dataContacts)
                {
                    SMSProcess smsProcess = new SMSProcess();

                    tempMsg = bm.Message;

                    if (bm.Message.Contains("{Name}"))
                    {
                        tempMsg = bm.Message.Replace("{Name}", item.Name);
                    }

                    if (bm.Message.Contains("{Email}"))
                    {
                        tempMsg = bm.Message.Replace("{Email}", "Eamil");
                    }

                    SenderModel um = new SenderModel()
                    {
                        SenderNumberId = bm.SenderNumberId,
                        Message = tempMsg,
                        Numbers = item.Number,
                    };

                    int status = smsProcess.Process(userId, um);


                    if (status == 1)
                    {                      
                        sucessCount++;
                    }
                    else if (status == 2)
                    {
                        failCount++;
                    }
                    else if (status == 3)
                    {
                        break;
                    }

                }
                this.UpdateData();

                ViewBag.SuccessMessage = "Success "+sucessCount+" Failed "+failCount;
                //return RedirectToAction("Home\Index");
                return View(bsm);

            }

            return View(bsm);
        }


    }
}