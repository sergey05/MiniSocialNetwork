using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Post
    {
        public Guid PostId { get; set; }
        public DateTime PostedTime { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<User> Likes { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
