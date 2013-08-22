using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class UserService : ServiceBase<User>,IUserService
    {
        public bool AddNewUser(User user)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                if (IsUsedEmail(user.Email))
                {
                    return false;
                }
                user.Password = Encryptor.GetMd5Hash(user.Password);
                var userRepository = unitOfWork.GetRepository<User>();
                userRepository.Insert(user);
                unitOfWork.CommitChanges();
                return true;
            }
        }

        public bool IsUsedEmail(string email)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                return userRepository.Single(o => o.Email == email) != null;
            }
        }

        public bool VerifyUserPassword(string email, string password)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                return userRepository.Single(user => user.Email == email && Encryptor.VerifyMd5Hash(password, user.Password)) != null;
            }
        }
    }
}
