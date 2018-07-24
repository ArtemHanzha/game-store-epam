using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Task.Contracts.Abstracts;

namespace Task.Services.Interfaces.Generic
{
    public interface IReadOnlyService <T> where T : AbstractDbObject
    {
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate = null);

        T GetById(int itemId);
    }
}