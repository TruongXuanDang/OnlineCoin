namespace OnlineCoin.Migrations
{
    using OnlineCoin.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OnlineCoin.Models.OnlineCoinContext>
    {
        List<Account> listAccount = new List<Account>();
        List<AccountRole> listAccountRole = new List<AccountRole>();
        List<Coin> listCoin = new List<Coin>();
        List<News> listNews = new List<News>();

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineCoin.Models.OnlineCoinContext context)
        {
            AddAccount("Tran", "An");
            AddAccount("Tran", "Binh");
            AddAccount("Tran", "Tuan");
            AddAccount("Nguyen", "Can");
            AddAccount("Dang", "Trung");

            AddAccountRole("User");
            AddAccountRole("Admin");

            AddNews("Maintain your Finance and Technology Expertise", "Join us at our events to watch pitches by companies deploying the latest technology, watch our video library of over 400 videos, and follow our newsletters with valuable information on the latest reports and happenings in the scene.");

            //context.Accounts.AddRange(listAccount);
            //context.AccountRoles.AddRange(listAccountRole);
            context.News.AddRange(listNews);
            context.SaveChanges();
        }

        private void AddAccount (string firstName, string lastName)
        {
            listAccount.Add(new Account
            {
                FirstName = firstName,
                LastName = lastName,
                CreatedAt = DateTime.Now,
                Status = Account.AccountStatus.Active,

            });
        }

        private void AddAccountRole (string description)
        {
            listAccountRole.Add(new AccountRole
            {
                Description = description,
                CreatedAt = DateTime.Now,
                Status = AccountRole.AccountRoleStatus.Active,
            });
        }

        private void AddNews (string title, string content)
        {
            listNews.Add(new News
            {
                Title = title,
                Content = content,
                PublishedAt = DateTime.Now,
                Status = News.AuthorStatus.Active,
            });
        }
    }
}
