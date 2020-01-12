using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineCoin.Models
{
    public class News
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PublishedAt { get; set; }
        public AuthorStatus Status { get; set; }
        public enum AuthorStatus
        {
            Active = 1,
            DeActive = 0,
            Saved = 2,
            Deleted = 3
        }
        public virtual Author Author { get; set; }
    }
}