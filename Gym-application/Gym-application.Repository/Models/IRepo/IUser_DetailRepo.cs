using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.IRepo
{
    public interface IUser_DetailRepo
    {
        Task<User_Detail> GetUserDetail(string UserId);
        void Add_User_Detail(User_Detail user_Detail);
        Task<int> SaveChangesAsync();
    }
}
