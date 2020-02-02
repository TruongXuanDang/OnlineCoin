using System;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCoin.Models
{
    public class AccountRole : IdentityRole
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountRoleStatus Status { get; set; }
        public enum AccountRoleStatus
        {
            Active = 1,
            DeActive = 0,
            Saved = 2,
            Deleted = 3
        }
    }
}