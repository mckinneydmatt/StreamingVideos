using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Models
{
    public class MovieListItem
    {
        public int MovieId { get; set; }
        [Display(Name = "Title")]
        public string MovieTitle { get; set; }
        [Display(Name = "Runtime")]
        public int MovieRuntime { get; set; }
        [Display(Name = "Genre")]
        public string MovieGenre { get; set; }
        [Display(Name = "License ends")]
        public DateTimeOffset MovieLicenseEndDate { get; set; }
        [Display(Name = "Views")]
        public int MovieViews { get; set; } = 0;

    }
}
