using Project.Auth;
using Project.Models.Entities;
using Project.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.Controllers
{

    [AdminAccess, BasicAuthFilter]

    public class AdminController : Controller
    {
        //private object httpContext;



        


        public ActionResult Index()
        {
            DashboardModel hm = new DashboardModel();




            var userId = (int)Session["UserId"];
            //var userId = 5;
            var db = new ProjectEntities();

            var dataTemplates = db.SenderNumbers.ToList();
            var dataGroups = db.Groups.ToList();
            var failedMessages = (from c in db.Messages where c.Status == "Failed" select c).ToList();
            var successMessages = (from c in db.Messages where c.Status == "Success" select c).ToList();
            var sendMessages = db.Messages.ToList();
            var users = db.Users.ToList();
            hm.Templates = dataTemplates.Count.ToString();
            hm.Groups = dataGroups.Count.ToString();
            hm.Users = users.Count.ToString();
            hm.SendMessages = sendMessages.Count.ToString();
            hm.FailedMessages = failedMessages.Count.ToString();
            hm.SuccessMessages = successMessages.Count.ToString();
            hm.User = (from c in db.Users where c.Id == userId select c).FirstOrDefault();


            return View(hm);
        }

       


    }
}