using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Data.Entities
{
    public class User
    {
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public string UserAge { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public DateTimeOffset MemberSince { get; set; }
    }
}
