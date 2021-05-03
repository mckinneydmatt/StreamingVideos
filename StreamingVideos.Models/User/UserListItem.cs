using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamingVideos.Models.User
{
    public class UserListItem
    {
        public string Name { get; set; }
        [Display(Name = "Email address")]
        public string UserEmail { get; set; }
        [Display(Name = "Age")]
        public int UserAge { get; set; }
        public Guid UserId { get; set; }
        [Display(Name = "Member since")]
        public DateTimeOffset MemberSince { get; set; }

    }
}
