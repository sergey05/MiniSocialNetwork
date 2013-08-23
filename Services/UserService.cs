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
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
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

        public void UpdateUser(User user)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                userRepository.Update(user);
                unitOfWork.CommitChanges();
            }
        }

        public bool IsUsedEmail(string email)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                return userRepository.Single(o => o.Email == email) != null;
            }
        }

        public bool VerifyUserPassword(string email, string password)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                return userRepository.Single(user => user.Email == email && Encryptor.VerifyMd5Hash(password, user.Password)) != null;
            }
        }

        public void AddUserToBlackList(User user, User blackListedUser)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                userRepository.Attach(user);
                userRepository.Attach(blackListedUser);
                user.MyBlackList.Add(blackListedUser);
                unitOfWork.CommitChanges();
            }
        }

        public void Subcribe(User user, User subscriber)
        {
            using (var unitOfWork = UnitOfWork.GetUnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var subscriptionRepository = unitOfWork.GetRepository<Subscription>();
                userRepository.Attach(user);
                userRepository.Attach(subscriber);
                var subscription = new Subscription() {Subscriber = subscriber, User = user};
                subscriptionRepository.Insert(subscription);
                unitOfWork.CommitChanges();
            }
        }

    }
}
