using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CommentId { get; set; }
        public DateTime AdditionTime { get; set; }
        public string Content { get; set; }
        public virtual Post Post { get; set; }
        public virtual User Commentator { get; set; }
    }
}
