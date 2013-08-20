using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Message
    {
        public Guid MessageId { get; set;}
        public string Content { get; set; }
        public string Subject { get; set; }
        public virtual User Sender { get; set; }
        public virtual ICollection<User> Recipients { get; set; }
        public DateTime SendingTime { get; set; }
    }
}
