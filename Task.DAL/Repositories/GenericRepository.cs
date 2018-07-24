using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Task.Contracts.Abstracts;
using Task.DAL.Context;
using Task.DAL.Interfaces;

namespace Task.DAL.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : AbstractDbObject
    {

        private readonly GameStoreContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(GameStoreContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }


        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, bool getDeleted = false)
        {
            var quiue = _dbSet as IQueryable<T>;

            if (predicate != null)
            {
                quiue = quiue.Where(predicate);
                if (!getDeleted)
                {
                    quiue = quiue.Where(q => q.IsDeleted == false);
                }
            }
            return quiue.ToList(); //TODO: argument exception when string.Equals(s1, s2)
        }

        public T Get(int itemId, bool getDeleted = false)
        {
            var item = _dbSet.FirstOrDefault(i => i.Id == itemId);
            if (item != null && item.IsDeleted && !getDeleted)
            {
                return null;
            }
            return item;
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int itemId)
        {
            var obj = Get(itemId);
            obj.IsDeleted = true;
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }
    }
}