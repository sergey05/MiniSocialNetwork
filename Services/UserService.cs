using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class UserService : ServiceBase<User>, IUserService
    {

        public UserService(IUnitOfWork unitOfWork): base(unitOfWork)
        {
        }

        public bool AddNewUser(User user)
        {
            if (IsUsedEmail(user.Email))
            {
                return false;
            }
            user.Password = Encryptor.GetMd5Hash(user.Password);
            Insert(user);
            UnitOfWork.CommitChanges();
            return true;
        }

        public bool IsUsedEmail(string email)
        {
            return Single(o => o.Email == email) != null;
        }

        public bool VerifyUserPassword(string email, string password)
        {
            return Single(user => user.Email == email && Encryptor.VerifyMd5Hash(password, user.Password)) != null;
        }

        public void AddNewMessage(Message message)
        {
            message.Sender.Messages.Add(message);
        }

    }
}
