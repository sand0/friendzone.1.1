﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Friendzone.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        //IEnumerable<T> Filrer(Func<T, bool> predicate);
        IQueryable<T> Filrer(Func<T, bool> predicate);
        T Get(int id);

        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);

        void Save();
    }
}
