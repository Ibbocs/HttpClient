namespace HttpClient
{
    public class Todo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }

    public class CreatePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }

    public class CreatePostDTO
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public int UserId { get; set; }
    }

}
