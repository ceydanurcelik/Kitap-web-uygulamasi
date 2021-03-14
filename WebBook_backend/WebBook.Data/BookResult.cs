namespace WebBook.Data
{
    public class BookResult : ResultMessage
    {
        public string Title { get; set; }
        public string Comment { get; set; }
        public string Author { get; set; }
        public string User { get; set; }
    }
}