using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels
{
    public class MessageRecipient
    {
        public Guid RecipientId { get; set; }
        public Guid MessageId { get; set; }
        public virtual User Recipient { get; set; }
        public virtual Message Message { get; set; }
    }
}
