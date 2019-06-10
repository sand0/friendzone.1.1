using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FriendZone.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();
        T Get(int id);

        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);

        void Save();
    }
}
