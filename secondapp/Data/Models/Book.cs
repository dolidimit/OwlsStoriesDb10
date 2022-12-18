using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{
    public class Book
    {
        
        public int Id { get; init; }

        [Required]
        [MaxLength(45)]
        public string Title { get; set; }

        [Required]
        [MaxLength(85)]
        public string RTitle { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(80)]
        public string Topic { get; set; }

        [Required]
        [MaxLength(200)]
        public string Author { get; set; }

        public int Pages { get; set; }

        [Required]
        public string StoryCon { get; set; }

        public string BookPdf { get; set; }

        [Required]
        public string BookLinkDw { get; set; }


    }
}
