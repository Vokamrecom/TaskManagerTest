namespace TaskManager.Application.Comments.Get
{
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<CommentDto> Comments { get; set; }
    }

    public class CommentDto
    {
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
