﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportDash.Repository
{
    public interface IUserRepository
    {
        string GetFullName(string id);
        void EditFullName(string id, string newName);
    }
}