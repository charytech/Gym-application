﻿using Gym_application.Repository.Models.IRepo;
using System;
using System.Collections.Generic;
using System.Text;
using Gym_application.Repository.Models.DataBase;
using System.Linq;
using Gym_application.Repository.Data;

namespace Gym_application.Repository.Models.Repo
{
    public class UserRepo : IUserRepo
    {
        private IApplicationDbContextRepo _db;
        public UserRepo(IApplicationDbContextRepo db)
        {
            _db = db;
        }
        public IQueryable<User> LoadUsers() => _db.User;
    }
}
