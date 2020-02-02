using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using OnlineCoin.Models;
using Microsoft.AspNet.Identity.Owin;

//[assembly: OwinStartup(typeof(OnlineCoin.App_Start.IdentityConfig))]
namespace OnlineCoin.App_Start
{
    public class IdentityConfig
    {

    }

    public class MyUserManager : UserManager<Account>
    {
        public MyUserManager(IUserStore<Account> store) : base(store) { }
        public static MyUserManager Create(IdentityFactoryOptions<MyUserManager> options, IOwinContext context)
        {
            var manager = new MyUserManager(new UserStore<Account>(new OnlineCoinContext()));
            manager.UserValidator = new UserValidator<Account>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<Account>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<Account>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });

            manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<Account>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

    }

    public class EmailService : IIdentityMessageService
    {

        public Task SendAsync(IdentityMessage message)
        {
            MailMessage mail = new MailMessage();
            SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
            smtpServer.Credentials = new System.Net.NetworkCredential("lamvtth1805001@fpt.edu.vn", "cdnacyme");
            smtpServer.Port = 587;
            smtpServer.EnableSsl = true;

            mail.From = new MailAddress("lamvtth1805001@fpt.edu.vn");
            mail.To.Add(message.Destination);
            mail.Subject = message.Subject;
            mail.Body = message.Body;

            smtpServer.Send(mail);
            return Task.FromResult(0);
        }
    }
}