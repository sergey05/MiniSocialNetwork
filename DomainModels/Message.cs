using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DomainModels
{
    public class Message
    {
        private ICollection<User> _recipients;

        public Message()
        {
            _recipients = new List<User>();
        }
        public Guid MessageId { get; set;}
        public string Content { get; set; }
        public string Subject { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<User> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }
        public DateTime SendingTime { get; set; }
    }
}
