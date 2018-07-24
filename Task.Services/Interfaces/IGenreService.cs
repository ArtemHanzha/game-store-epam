using System.Collections.Generic;
using Task.Contracts.Modes;
using Task.Services.Interfaces.Generic;

namespace Task.Services.Interfaces
{
    public interface IGenreService : IService<Genre>, INameFilterService<Genre>
    {
        
    }
}