using System;
using System.Collections.Generic;

namespace BlockMusicAPI.Models
{
    public partial class Users
    {
        public Users()
        {
            Purchases = new HashSet<Purchases>();
            Songs = new HashSet<Songs>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateRegistered { get; set; }

        public virtual ICollection<Purchases> Purchases { get; set; }
        public virtual ICollection<Songs> Songs { get; set; }
    }
}
