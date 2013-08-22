using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool AddNewUser(User user)
        {
            if (IsUsedEmail(user.Email))
            {
                return false;
            }
            user.Password = Encryptor.GetMd5Hash(user.Password);
            var userRepository = _unitOfWork.GetRepository<User>();
            userRepository.Insert(user);
            _unitOfWork.CommitChanges();
            return true;
        }

        public bool IsUsedEmail(string email)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.Single(o => o.Email == email) != null;
        }

        public bool VerifyUserPassword(string email, string password)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            return userRepository.Single(user => user.Email == email && Encryptor.VerifyMd5Hash(password, user.Password)) != null;
        }

        public void AddNewMessage(Message message)
        {
            message.Sender.OutboxMessages.Add(message);
        }

    }
}
