namespace Task1.Models.ViewModels.Sigle
{
    public class CommentViewModel : BaseViewModel
    {
        public string Text { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public int GameId { get; set; }

        public int ParrentId { get; set; }
    }
}