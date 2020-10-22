﻿using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface ICategoryRepository<T> : IRepository<T> where T : Category
    {
    }
}