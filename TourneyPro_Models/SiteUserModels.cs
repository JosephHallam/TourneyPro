using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourneyPro_Models
{
    public class SiteUserCreate
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }
    }
    public class SiteUserEdit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
    public class SiteUserListItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
    }
    public class SiteUserDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        [Display(Name = "Verified?")]
        public bool IsVerified { get; set; }
        public byte[] Image { get; set; }
    }
}
