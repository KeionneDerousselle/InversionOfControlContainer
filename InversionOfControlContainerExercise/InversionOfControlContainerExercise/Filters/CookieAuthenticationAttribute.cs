using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;

namespace InversionOfControlContainerExercise.Filters
{
    public class CookieAuthenticationAttribute : FilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            bool redirect = true;
            if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var name = FormsAuthentication.FormsCookieName;
                var cookie = filterContext.HttpContext.Request.Cookies[name];
                if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                {
                    var ticket = FormsAuthentication.Decrypt(cookie.Value);
                    if (ticket != null && !ticket.Expired)
                    {
                        filterContext.HttpContext.User = new GenericPrincipal(new FormsIdentity(ticket), new string[] { });
                        redirect = false;
                    }
                }
            }

            if (redirect)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }
    }
}