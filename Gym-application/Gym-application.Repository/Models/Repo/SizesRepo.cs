using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Linq;
using Gym_application.Repository.Data;
using Microsoft.EntityFrameworkCore;

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
    }
}
