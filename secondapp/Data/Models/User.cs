using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{
    public class User : IdentityUser 
    {

        [MaxLength(30)]
        public string FullName { get; set; }

        public List<FinshedBook> FinshedBooksU { get; set; } = new List<FinshedBook>();

    }
}
