using System;

namespace DomainModels
{
    public class Repost:Post
    {
        public virtual Post OriginalPost { get; set; }
    }
}
