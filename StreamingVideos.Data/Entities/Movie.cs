using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Data.Entities
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        [Required]
        [Display(Name = "Movie Title")]
        public string MovieTitle { get; set; }
        [Required]
        public int MovieRuntime { get; set; }
        [Required]
        public string MovieGenre { get; set; }
        [Required]
        public DateTimeOffset MovieLicenseEndDate { get; set; }
        [Required]
        public int MovieViews { get; set; } = 0;
    }
}
