using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace secondapp.Data.Models
{
    public class Genre
    {
       
        public int Id { get; init; }

        public string Name { get; set; }

        public IEnumerable<Story> Stories { get; init; } = new List<Story>();


    }
}
