namespace Task1.ViewModel.Sigle
{
    public class CommentViewModel : BaseViewModel
    {
        public string Text { get; set; }

        public string UserName { get; set; }

        public string Title { get; set; }

        public CommentViewModel Parrent { get; set; }
    }
}