using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{
    public class Event
    {
      
        public int Id { get; init; }

        [Required]
        [MaxLength(105)]
        public string Title { get; set; }

        [Required]
        [MaxLength(105)]
        public string SubTitle { get; set; }

        [Required]
        [MaxLength(105)]
        public string BookTitle { get; set; }

        [Required]
        [MaxLength(85)]
        public string GuestAuthor { get; set; }

        [Required]
        public string GuestAuthorImage { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string StartTime { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(5)]
        public string EndTime { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Range(100,300)]
        public int BookStock { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address { get; set; }

        [Required]
        [MaxLength(180)]
        public string Description { get; set; }

        [Required]
        [MaxLength(4000)]
        public string BookResume { get; set; }

        [Required]
        public string BookLinkDw { get; set; }

        public string BookPdf { get; set; }

        public int UsersCounter { get; set; }


        public List<EventUser> EventsUsers { get; set; } = new List<EventUser>();


    }
}
