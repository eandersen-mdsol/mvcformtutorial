using System;
using System.ComponentModel.DataAnnotations;

namespace MVCFormsExample.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public DateTime Published { get; set; }

        [Required]
        public int Rating { get; set; }
    }
}