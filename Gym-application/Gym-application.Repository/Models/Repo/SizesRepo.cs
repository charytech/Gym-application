using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Linq;
using Gym_application.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.Repo
{
    public class SizesRepo : ISizesRepo
    {
        private IApplicationDbContextRepo _db;
        public SizesRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }
        public IQueryable<Size> GetUserSizes(string UserId) => _db.Sizes.Where(t => t.UserId == UserId).AsNoTracking();
        public Task<Size> GetActualSize(string UserId) => _db.Sizes.Where(t => t.UserId == UserId).OrderByDescending(t=>t.Create_Date).FirstOrDefaultAsync();
        public void SaveActualSizes(Size size)
        {
            var a = GetActualSize(size.UserId).Result;
            bool c = a.My_Equal(size);
            if (a != null && !c)
            {
                a.Kind_Of_Sizes = Kind_of_Sizes.Story;
                _db.Update(a);
            }
            if (!c)
            {
                _db.Sizes.Add(size);
            }
        }
        public Task<int> SaveChangesAsync()
        {
            return _db.SaveChangesAsync();
        }
    }
}
