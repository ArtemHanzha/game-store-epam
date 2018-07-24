using Ninject.Modules;
using Ninject.Web.Common;
using Task.DAL;
using Task.DAL.Context;
using Task.DAL.Interfaces;
using Task.DAL.Repositories;

namespace Task.Infrastructure.DependencyResolution
{
    public class NinjectDalModule : NinjectModule
    {
        private readonly string _efConnectionString;

        public NinjectDalModule(string efConnectionString)
        {
            _efConnectionString = efConnectionString;
        }

        public override void Load()
        {

            Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));

            Bind<GameStoreContext>().ToSelf().InRequestScope()
                .WithConstructorArgument(_efConnectionString);

            Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}