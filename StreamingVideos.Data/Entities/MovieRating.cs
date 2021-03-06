using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Data.Entities
{
    public class MovieRating
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Movie))]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        [Required, Range(0, 5, ErrorMessage ="Please choose a rating between 1 and 5")]
        public double StarRating { get; set; }

    }
}
