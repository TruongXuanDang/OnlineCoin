using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoin.Models
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
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