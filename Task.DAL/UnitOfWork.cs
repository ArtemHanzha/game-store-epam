using Task.DAL.Context;
using Task.DAL.Interfaces;

namespace Task.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GameStoreContext _dbContext;

        public UnitOfWork(GameStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}