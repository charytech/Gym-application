using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using Gym_application.Repository.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.Repo
{
    public class User_DetailRepo : IUser_DetailRepo
    {
        private IApplicationDbContextRepo _db;
        public User_DetailRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }

        public void Add_User_Detail(User_Detail user_Detail) => _db.User_Details.Add(user_Detail);
        public Task<User_Detail> GetUserDetail(string UserId) => _db.User_Details.AsNoTracking().SingleOrDefaultAsync(m => m.Id == UserId);
        public Task<int> SaveChangesAsync()=> _db.SaveChangesAsync();
 
        
    }
}
