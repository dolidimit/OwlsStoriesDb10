using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Admin
{
    public class AdminAddEventModel
    {

        public int Id { get; set; }

        [Required]
        [MaxLength(105)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subtitle")]
        [MaxLength(105)]
        public string SubTitle { get; set; }

        [Required]
        [MaxLength(105)]
        public string BookTitle { get; set; }

        [Required]
        [Display(Name = "Guest Author")]
        [MaxLength(85)]
        public string GuestAuthor { get; set; }

        [Required]
        [Display(Name = "Author Image Url")]
        [Url]
        public string GuestAuthorImage { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        [MinLength(5)]
        [MaxLength(5)]
        public string StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        [MinLength(5)]
        [MaxLength(5)]
        public string EndTime { get; set; }


        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Image Url")]
        [Url]
        public string ImageUrl { get; set; }

        [Display(Name = "Book Stock Count")]
        [Range(100, 300)]
        public int BookStock { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(180)]
        public string Description { get; set; }


        public int UsersCounter { get; set; }

        [Required]
        [MaxLength(4000)]
        public string BookResume { get; set; }

        [Display(Name = "Choose your PDF File")]
        [Required]
        public IFormFile BookPdfFil { get; set; }

        public string BookPdf { get; set; }

        [Required]
        public string BookLinkDw { get; set; }
    }
}
