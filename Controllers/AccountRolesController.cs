using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineCoin.Models;

namespace OnlineCoin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountRolesController : Controller
    {
        private OnlineCoinContext dbContext = new OnlineCoinContext();
        private RoleManager<AccountRole> roleManager;

        public AccountRolesController()
        {
            RoleStore<AccountRole> roleStore = new RoleStore<AccountRole>(dbContext);
            roleManager = new RoleManager<AccountRole>(roleStore);
        }
        // GET: AccountRoles
        public ActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRole(string name)
        {
            var accountRole = new AccountRole()
            {
                Name = name,
                CreatedAt = DateTime.Now,
            };
            IdentityResult result = roleManager.Create(accountRole);
            return View("AddRole");
        }
    }
}