using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Task.DAL.Interfaces
{
    public interface IRepository <T>
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null, bool getDeleted = false);

        T Get(int itemId, bool getDeleted = false);

        void Update(T item);

        void Delete(int itemId);

        void Create(T item);
    }
}