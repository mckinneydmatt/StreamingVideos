using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Data.Entities
{
    public class Episode
    {
        [Key]
        public int EpisodeId { get; set; }
        [ForeignKey(nameof(TVShow))]
        public int TVShowId { get; set; }
        [Required]
        public string EpisodeTitle { get; set; }
        [Required]
        public int EpisodeRuntime { get; set; }
        public virtual TVShow TVShow { get; set; }




    }
}
