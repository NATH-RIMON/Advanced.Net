using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace Project.Auth
{
    public class BasicAuthFilter : ActionFilterAttribute, IAuthenticationFilter
    {


        public void OnAuthentication(AuthenticationContext filterContext)
        {
            var user = filterContext.HttpContext.User;
            if (user == null || !user.Identity.IsAuthenticated)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectToRouteResult("Default",
                    new System.Web.Routing.RouteValueDictionary{
                        {"controller", "Auth/Login"},
                        {"action", "Logout"},
                        {"returnUrl", filterContext.HttpContext.Request.RawUrl}
                    });
            }
        }
    }
}