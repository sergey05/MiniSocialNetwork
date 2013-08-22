using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModels;

namespace Services
{
    public interface IMessageService : IServiceBase<Message>
    {
        void AddNewMessage(Message message, User sender, ICollection<User> recipients);
    }
}
