using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Data.Entities
{
    public class TVShow
    {
        [Key]
        public int TVShowId { get; set; }
        [Required]
        public string TVShowTitle { get; set; }
        [Required]
        public int TVShowEpisodes { get; set; }
        [Required] 
        public int TVShowSeasons { get; set; }
        [Required]
        public string TVShowGenre { get; set; }
        [Required]
        public DateTimeOffset TVShowLicenseEndDate { get; set; }
        public int TVShowViews { get; set; } = 0;
    }
}
