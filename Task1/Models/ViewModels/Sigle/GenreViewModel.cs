using System.Collections.Generic;

namespace Task1.Models.ViewModels.Sigle
{
    public class GenreViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public IEnumerable<GenreViewModel> SubGenres { get; set; }
    }
}