﻿using Gym_application.Repository.Models.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym_application.Repository.Models.IRepo
{
    public interface ISizesRepo
    {
        IQueryable<Size> GetUserSizes(string UserId);
        Task<Size> GetActualSize(string UserId);
        void SaveActualSizes(Size size);
        Task<int> SaveChangesAsync();

    }
}
