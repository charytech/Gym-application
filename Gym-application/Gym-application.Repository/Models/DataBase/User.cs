using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Gym_application.Repository.Models.DataBase
{
    // Add profile data for application users by adding properties to the User class
    public class User : IdentityUser
    {
        public User()
        {

            this.User_Detail = new HashSet<User_Detail>();
            this.Size = new HashSet<Size>();
        }
        public string FirstName { get; set; }
        public string SurName { get; set; }
        
        public virtual ICollection<Size> Size { get; private set; }
        public virtual ICollection<User_Detail> User_Detail { get;private set; }
        public virtual ICollection<Diet> Diet { get;private set; }
        public virtual ICollection<Nutritional_Value> Nutritional_Value { get; private set; }
        
    }
}
