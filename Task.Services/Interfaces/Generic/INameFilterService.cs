using Task.Contracts.Abstracts;

namespace Task.Services.Interfaces.Generic
{
    public interface INameFilterService<T> where T : AbstractDbObject
    {
        T GetByName(string name);
    }
}