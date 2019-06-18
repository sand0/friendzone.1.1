using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Friendzone.DAL.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected readonly AppDbContext _context;
        protected DbSet<T> Entities;
        protected string ErrorMessage = string.Empty;

        public Repository(AppDbContext context)
        {
            _context = context;
            Entities = context.Set<T>();
        }


        public IQueryable<T> All() => Entities;

        public IQueryable<T> Filrer(Func<T, bool> predicate) => Entities.Where(predicate) as IQueryable<T>;

        public T Get(int id) => Entities.SingleOrDefault(e => e.Id == id);


        public T Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            Entities.Add(entity);
            _context.SaveChanges();
            return entity;
        }


        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }


        public bool Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            if (Entities.Contains(entity))
            {
                Entities.Remove(entity);
                _context.SaveChanges();
                return true;
            }
            return false;
        }


        public void Save()
        {
            _context.SaveChanges();
        }
    }
}