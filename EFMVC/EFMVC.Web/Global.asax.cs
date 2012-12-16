using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;
using EFMVC.Web.Core.Authentication;
using EFMVC.Web.Core.Models;
using EFMVC.Web.Core.ActionFilters;

namespace EFMVC.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new UserFilter());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Category", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        public override void Init()
        {
            this.PostAuthenticateRequest += this.PostAuthenticateRequestHandler;
            base.Init();
        }
        private void PostAuthenticateRequestHandler(object sender, EventArgs e)
        {
            HttpCookie authCookie = this.Context.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (IsValidAuthCookie(authCookie))
            {
                var formsAuthentication = DependencyResolver.Current.GetService<IFormsAuthentication>();

                var ticket = formsAuthentication.Decrypt(authCookie.Value);
                var efmvcUser = new EFMVCUser(ticket);
                string[] userRoles = { efmvcUser.RoleName };
                this.Context.User = new GenericPrincipal(efmvcUser, userRoles);              
                formsAuthentication.SetAuthCookie(this.Context, ticket);
            }
        }
        private static bool IsValidAuthCookie(HttpCookie authCookie)
        {
            return authCookie != null && !String.IsNullOrEmpty(authCookie.Value);
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            Bootstrapper.Run();
        }
    }
}