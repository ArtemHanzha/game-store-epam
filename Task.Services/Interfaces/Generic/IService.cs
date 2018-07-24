using Task.Contracts.Abstracts;

namespace Task.Services.Interfaces.Generic
{
    public interface IService <T> : IReadOnlyService<T> where T : AbstractDbObject
    {
        void Delete(int itemId);

        void Update(T item);

        void Create(T item);
    }
}