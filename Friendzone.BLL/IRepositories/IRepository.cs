using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Friendzone.Core.IRepositories
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        IEnumerable<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = "");

        T Get(int id);

        T Create(T entity);
        T Update(T entity);
        bool Delete(T entity);

        void Save();
    }
}
