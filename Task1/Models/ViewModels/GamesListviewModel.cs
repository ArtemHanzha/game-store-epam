using System.Collections.Generic;
using Task1.Models.ViewModels.Sigle;

namespace Task1.Models.ViewModels
{
    public class GamesListviewModel
    {
        public IEnumerable<GameViewModel> Games { get; set; }
    }
}