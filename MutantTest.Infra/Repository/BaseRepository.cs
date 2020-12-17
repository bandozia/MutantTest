﻿using Microsoft.EntityFrameworkCore;
using MutantTest.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MutantTest.Infra.Repository
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected readonly AppContext context;
        protected readonly DbSet<T> dbSet;

        public BaseRepository(AppContext context)
        {
            this.context = context;
            dbSet = context.Set<T>();
        }
    }
}
