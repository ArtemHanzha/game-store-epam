using System.Data.Entity;
using Task.Contracts.Modes;

namespace Task.DAL.Context
{
    public class GameStoreContext : System.Data.Entity.DbContext
    {
        public DbSet<Game> Games { get; set; }

        public DbSet<Genre> Genres { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<PlatformType> PlatformTypes { get; set; }

        public GameStoreContext()
            :base("name=GameStoreDbEntities")
        {
            Database.SetInitializer(new DbInitializer());
            Database.Initialize(true);
        }
    }
}