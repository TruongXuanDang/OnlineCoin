using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoin.Models
{
    public class Author
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string NickName { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
        public DateTime CreatedAt { get; set; }
        public AuthorStatus Status { get; set; }
        public enum AuthorStatus
        {
            Active = 1,
            DeActive = 0,
            Saved = 2,
            Deleted = 3
        }
        public virtual ICollection<News> News { get; set; }
    }
}