using System;

namespace DomainModels
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        public string Body { get; set; }
        public string Subject { get; set; }
        public virtual Post Post { get; set; }
        public virtual User Commenter { get; set; }
    }
}
