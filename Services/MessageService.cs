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
                message.User = sender;
                foreach (var recipient in recipients)
                {
                    userRepository.Attach(recipient);
                    message.Recipients.Add(recipient);
                }
                messageRepository.Insert(message);
                unitOfWork.CommitChanges();
            }
        }
    }
}
