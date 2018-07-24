using System.Collections.Generic;
using Task.Contracts.Modes;
using Task.Services.Interfaces.Generic;

namespace Task.Services.Interfaces
{
    public interface IGameService : IService<Game>
    {
        Game GetByKey(string key);

        IEnumerable<Game> GetByGenre(string genre);

        IEnumerable<Game> GetByPlatformType(string platformType);
    }
}