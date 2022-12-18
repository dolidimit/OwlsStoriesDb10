using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Books
{
    public class AddBookFormModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(45)]
        public string Title { get; init; }


        [Required]
        [MaxLength(85)]
        public string RTitle { get; set; }


        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Topic { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(200)]
        public string Author { get; init; }


        public int Pages { get; init; }


        [Display(Name = "Resume")]
        [MinLength(40)]
        [StringLength(int.MaxValue, ErrorMessage = "Story must have at least 40 characters.", MinimumLength = 40)]

        public string StoryCon { get; init; }

        [Required]
        public string BookLinkDw { get; init; }

        [Display(Name = "Choose your PDF File")]
        [Required]
        public IFormFile BookPdfFil { get; set; }
        public string BookPdf { get; set; }
    }
}
