using System;
using System.ComponentModel.DataAnnotations;

namespace AtTime.Core.Models
{
    public class Point
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime Time { get;set; }
        [Required]
        public int AuthorId { get; set; }
        public User Author { get; set; }

        public Point(DateTime time, int authorId)
        {
            Time = time;
            AuthorId = authorId;
        }

        public Point()
        {

        }
    }
}
