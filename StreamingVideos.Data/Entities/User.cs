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
        public string Name { get; set; }
        [Required]
        public string UserEmail { get; set; }
        [Required]
        public int UserAge { get; set; }
        [Key]
        public Guid UserId { get; set; }
        [Required]
        public DateTimeOffset MemberSince { get; set; }
        public bool AdultContent
        {
            get
            {
                if (UserAge >= 18)
                {
                    return true;
                }
                else 
                    return false;
            }
        }
    }
}
