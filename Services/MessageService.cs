using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class MessageService : ServiceBase<Message>,IMessageService
    {
        public void AddNewMessage(Message message, User sender, ICollection<User> recipients)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var messageRepository = unitOfWork.GetRepository<Message>();
                var userRepository = unitOfWork.GetRepository<User>();
                userRepository.Attach(sender);
                userRepository.Attach(recipients.First());
                userRepository.Attach(recipients.Last());
                message.User = sender;
                message.Recipients.Add(recipients.First());
                message.Recipients.Add(recipients.Last());
                messageRepository.Insert(message);
                unitOfWork.CommitChanges();
            }
        }
    }
}
