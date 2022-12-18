using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Models.Admin
{
    public class AdminAddBookModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(105)]
        public string Title { get; init; }


        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(80)]
        public string Topic { get; init; }

        [Required]
        [MinLength(5)]
        [MaxLength(90)]
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
