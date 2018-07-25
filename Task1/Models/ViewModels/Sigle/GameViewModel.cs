using System.Collections.Generic;

namespace Task1.Models.ViewModels.Sigle
{
    public class GameViewModel : BaseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Key { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public IEnumerable<PlatformTypeViewModel> Platforms { get; set; }
    }
}