using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Auth;
using Project.Models.Entities;

namespace Project.Controllers
{
    [BasicAuthFilter, UserAccess]

    public class MessageController : Controller
    {
        // GET: Message
        public ActionResult Index()
        {
            //var userId = 5;
           // IQueryable<Message> data = IQueryable<new Message()>;


            var userId = (int)Session["UserId"];
                var db = new ProjectEntities();
                 var data = from c in db.Messages where c.UserId == userId select c;
                //var data = db.Groups.ToList();
                return View(data);
            

            //return View(data);


            
                
        }


        public ActionResult Delete(int Id)
        {
            var db = new ProjectEntities();
            var data = (from c in db.Messages where c.Id == Id select c).FirstOrDefault();
            db.Messages.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}