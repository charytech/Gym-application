using System;
using System.Collections.Generic;
using System.Text;

namespace Gym_application.Repository.Models.Repo
{
    public class Diet
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string UserId { get; set; }
        public string OwnerId { get; set; }
        public DateTime Created_Date { get; set; }
        public virtual User User { get; set; }
    }
}
