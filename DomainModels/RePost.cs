using System;

namespace DomainModels
{
    public class RePost:Post
    {
        public virtual User Owner { get; set; }
        public DateTime RepostTime { get; set; }
    }
}
