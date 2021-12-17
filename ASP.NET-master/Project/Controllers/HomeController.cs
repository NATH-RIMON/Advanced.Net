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
    
    [BasicAuthFilter, UserAccess]

    public class HomeController : Controller
    {
        //private object httpContext;



        public ActionResult Index()
        {
            DashboardModel hm = new DashboardModel();

            if (Session["UserId"] != null)
            {


                var userId = (int)Session["UserId"];
                //var userId = 5;
                var db = new ProjectEntities();

                var dataTemplates = (from c in db.Templates where c.UserId == userId select c).ToList();
                var dataGroups = (from c in db.Groups where c.UserId == userId select c).ToList();
                var failedMessages = (from c in db.Messages where c.UserId == userId && c.Status == "Failed" select c).ToList();
                var successMessages = (from c in db.Messages where c.UserId == userId && c.Status == "Success" select c).ToList();
                var sendMessages = (from c in db.Messages where c.UserId == userId select c).ToList();
                var usersData = (from c in db.Users where c.Id == userId select c).FirstOrDefault();
                hm.Templates = dataTemplates.Count.ToString();
                hm.Groups = dataGroups.Count.ToString();
                hm.Balance = usersData.Balance.ToString("N2");
                hm.SendMessages = sendMessages.Count.ToString();
                hm.FailedMessages = failedMessages.Count.ToString();
                hm.SuccessMessages = successMessages.Count.ToString();
                hm.User = (from c in db.Users where c.Id == userId select c).FirstOrDefault(); 
            }

            return View(hm);
        }

       



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string password)
        {
            if (Session["UserId"] != null)
            {
               
                var userId = (int)Session["UserId"];
                var db = new ProjectEntities();
                var usersData = (from c in db.Users where c.Id == userId select c).FirstOrDefault();
                User u = new User()
                {

                    Id = usersData.Id,
                    Name = usersData.Name,
                    Email = usersData.Email,
                    Password = password,
                    Balance = usersData.Balance,
                    Role = usersData.Role,
                    RegTime = usersData.RegTime

                };
                
               
                var data = (from c in db.Users where c.Id == userId select c).FirstOrDefault();
                db.Entry(data).CurrentValues.SetValues(u);
                db.SaveChanges();
                
            }
            ViewBag.SuccessMessage = "Password change Successfully";
            return View();
        }



    }
}