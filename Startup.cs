using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using OnlineCoin.App_Start;
using OnlineCoin.Models;
using Owin;

[assembly: OwinStartup(typeof(OnlineCoin.Startup))]
namespace OnlineCoin
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<OnlineCoinContext>(OnlineCoinContext.Create);
            app.CreatePerOwinContext<MyUserManager>(MyUserManager.Create);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login"),
            });
        }
    }
}