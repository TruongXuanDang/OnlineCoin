using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OnlineCoin.Models
{
    public class OnlineCoinContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OnlineCoinContext() : base("name=OnlineCoinContext")
        {
        }

        public System.Data.Entity.DbSet<OnlineCoin.Models.Account> Accounts { get; set; }

        public System.Data.Entity.DbSet<OnlineCoin.Models.AccountRole> AccountRoles { get; set; }

        public System.Data.Entity.DbSet<OnlineCoin.Models.News> News { get; set; }

        public System.Data.Entity.DbSet<OnlineCoin.Models.Coin> Coins { get; set; }
    }
}
