using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Gym_application.Repository.Models.Repo
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public User()
        {
            this.User_Detail = new HashSet<User_Detail>();
            this.Sizes = new HashSet<Sizes>();
        }
        public virtual ICollection<Sizes> Sizes { get; set; }
        public virtual ICollection<User_Detail> User_Detail { get; set; }
    }
}
