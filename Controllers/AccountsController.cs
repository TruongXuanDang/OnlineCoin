using System;
using OnlineCoin.App_Start;
using OnlineCoin.Models;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace OnlineCoin.Controllers
{
    public class AccountsController : Controller
    {
        private OnlineCoinContext dbContext;
        private MyUserManager userManager;

        public MyUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<MyUserManager>();
            }
            set
            {
                userManager = value;
            }
        }
        public OnlineCoinContext DbContext
        {
            get
            {
                return dbContext ?? HttpContext.GetOwinContext().Get<OnlineCoinContext>();
            }
            set
            {
                dbContext = value;
            }
        }

        public AccountsController()
        {

        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            Account account = UserManager.Find(username, password);
            if (account == null)
            {
                return HttpNotFound();
            }
            var ident = UserManager.CreateIdentity(account, DefaultAuthenticationTypes.ApplicationCookie);
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignIn(new Microsoft.Owin.Security.AuthenticationProperties { IsPersistent = false }, ident);

            return Redirect("/Home");
        }

        [HttpPost]
        public ActionResult Logout()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();
            return Redirect("/Home");
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Register(string username, string password, string firstname, string lastname)
        {
            var account = new Account()
            {
                UserName = username,
                FirstName = firstname,
                Email = username,
                LastName = lastname,
                CreatedAt = DateTime.Now,
                Status = Account.AccountStatus.Active

            };
            IdentityResult result = await UserManager.CreateAsync(account,password);
            return View("Register");
        }
    }
}
