using System;
using System.Collections.Generic;

namespace DomainModels
{
    public class Post
    {
        public Guid PostId { get; set; }
        public byte[] Image { get; set; }
        public string Body { get; set; }
        public virtual User Author { get; set; }
        public virtual ICollection<User> Likes { get; set; }
    }
}
