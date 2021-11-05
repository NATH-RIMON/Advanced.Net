using Project.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.Auth
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UserAccess : AuthorizeAttribute
    {
       

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var flag = base.AuthorizeCore(httpContext);
            if (flag)
            {
                var username = httpContext.User.Identity.Name;

                //System.Console.WriteLine(username);
                //                httpContext.User.Identity.IsAuthenticated
                var db = new ProjectEntities();


                var user = (from c in db.Users where c.Email == username select c).FirstOrDefault();


                if (user.Role == 2 || user.Role == 1) return true;

            }
            else
            {
                
            }
            return false;
        }
    }
}