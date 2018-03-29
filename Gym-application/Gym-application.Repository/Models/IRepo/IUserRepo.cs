using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym_application.Repository.Models.IRepo
{
    public interface IUserRepo
    {
        IQueryable<User> LoadUsers();
    }
}
