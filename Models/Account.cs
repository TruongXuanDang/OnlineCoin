using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineCoin.Models
{
    public class Account : IdentityUser
    {
        //public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public AccountStatus Status { get; set; }
        public enum AccountStatus
        {
            Active = 1,
            DeActive = 0,
            Saved = 2,
            Deleted = 3
        }
    }
}