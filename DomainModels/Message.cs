using System;

namespace DomainModels
{
    public class Message
    {
        public Guid MessageId { get; set;}
        public string Body { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Recipient { get; set; }
        public DateTime Time { get; set; }
    }
}
