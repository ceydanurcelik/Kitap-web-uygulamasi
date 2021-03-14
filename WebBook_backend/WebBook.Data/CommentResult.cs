namespace WebBook.Data
{
    public class CommentResult : ResultMessage
    {
        public string Book { get; set; }
        public string CommentText { get; set; }
        public string User { get; set; }
    }
}