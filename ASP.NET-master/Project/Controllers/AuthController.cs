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
    [AllowAnonymous]
    public class AuthController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {


            return View(new UserLoginModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginModel u)
        {
            if (ModelState.IsValid)
            {

                var db = new ProjectEntities();
                var user = (from c in db.Users where c.Email == u.Email && c.Password == u.Password select c).FirstOrDefault();

                if (user != null)
                {



                    FormsAuthentication.SetAuthCookie(user.Email, false);

                    var authTicket = new FormsAuthenticationTicket(1, user.Email, DateTime.Now, DateTime.Now.AddMinutes(20), false, user.Role.ToString());
                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    HttpContext.Response.Cookies.Add(authCookie);
                    Session.Add("userId", user.Id);
                    Session.Add("userName", user.Name);
                    return RedirectToAction("Index", "Home");










                    /*

                    FormsAuthentication.SetAuthCookie(u.Email, false);

                    return RedirectToAction("Index", "Home");

                    */

                }
                else
                {
                    ViewBag.ErrorMessage = "User not found or matched";
                    return View(u);
                }


            }

            return View(u);
        }

        public ActionResult Registration()
        {
            return View(new UserRegistrationModel());
        }

        [HttpPost]
        public ActionResult Registration(UserRegistrationModel u)
        {
            if (ModelState.IsValid)
            {

                User user = new User()
                {
                    Name = u.Name,
                    Email = u.Email,
                    Password = u.Password,
                    Balance = 10.0,
                    Role = 2,
                    RegTime = DateTime.Now.ToString()
                };



                var db = new ProjectEntities();
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");


            }
            return View(u);

        }


        public ActionResult Logout()
        {
            Session.Contents.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        public ActionResult LogCheck()
        {

            return RedirectToAction("Login");
        }
    }
}