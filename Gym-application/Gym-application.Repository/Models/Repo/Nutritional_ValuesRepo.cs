using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Gym_application.Repository.Models.Repo
{
    public class Nutritional_ValuesRepo : INutritional_ValuesRepo
    {
        private IApplicationDbContextRepo _db;
        public Nutritional_ValuesRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }

        public void AddValuesAsync(Nutritional_Value values)
        {
            throw new NotImplementedException();
        }

        public Task<List<Nutritional_Value>> GetValuesAsync()
        {
            //Thread.Sleep(2000);
           return _db.Nutritional_Values.ToListAsync();
        }

        public Task<int> SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
