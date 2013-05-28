using System;
using System.ComponentModel.DataAnnotations;

namespace MVCFormsExample.ViewModels
{
    public class BookViewModel
    {
        [Required]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }
        
        [Required]
        public string Author { get; set; }
        
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Date published")]
        public DateTime? DatePublished { get; set; }
        
        [Range(1,5)]
        [Display(Name = "Rating (1-5)")]
        public int Rating { get; set; }
    }
}