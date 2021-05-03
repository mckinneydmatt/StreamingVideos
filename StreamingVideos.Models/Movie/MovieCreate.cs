using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Models.Movie
{
    public class MovieCreate
    {
        [Required]
        public string MovieTitle { get; set; }
        [Required]
        public int MovieRuntime { get; set; }
        [Required]
        public string MovieGenre { get; set; }
        [Required]
        public DateTimeOffset MovieLicenseEndDate { get; set; }
        public int MovieViews { get; set; } = 0;
    }
}
