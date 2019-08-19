using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication1.Utils;

namespace WebApplication1.Security
{
    public class CustomSecurityAttribute : AuthorizeAttribute
    {
        private readonly string[] _AuthorizedRoles;
        public CustomSecurityAttribute(params string[] authorizedRoles)
        {
            _AuthorizedRoles = authorizedRoles;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            User ConnectedUser = Session.Instance.ConnectedUser;
            if (!_AuthorizedRoles.Contains(ConnectedUser?.Role))
            {
                //acces denied
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new Dictionary<string, object>
                    {
                        { "Controller", "Security" },
                        { "Action", "Login"},
                        { "Area", null}
                    }
                 ));

            }
            //access granted
        }
    }
}