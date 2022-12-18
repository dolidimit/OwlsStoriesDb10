using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace secondapp.Models.Posts
{
    public class AddPostFormModel
    {

        public string PImageUrl { get; set; }

        [Required]
        [MaxLength(25)]
        public string PostTopic { get; set; }

        public string PCurrentTime { get; set; }

        public string UserId { get; set; }

        public string UserEmailC { get; set; }

        public string UserFullNameC { get; set; }

        [Required]
        [MaxLength(300)]
        public string PostContent { get; set; }
    }
}
