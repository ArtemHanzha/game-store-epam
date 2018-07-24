using Ninject.Modules;
using Task.Services.Interfaces;
using Task.Services.Services;

namespace Task.Infrastructure.DependencyResolution
{
    public class NinjectBllModule : NinjectModule
    {
        public NinjectBllModule()
        {
            
        }

        public override void Load()
        {
            Bind<ICommentService>().To<CommentService>();
            Bind<IGameService>().To<GameService>();
            Bind<IGenreService>().To<GenreService>();
            Bind<IPlatformTypeService>().To<PlatformTypeService>();
        }
    }
}