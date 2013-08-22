using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using DomainModels;

namespace Services
{
    public class AdministrationService : ServiceBase<User>,IAdministrationService
    {
        public void MakeAdmin(Guid userId)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var user = userRepository.Single(o => o.UserId == userId);
                user.Role = Role.Admin;
                userRepository.Update(user);
                unitOfWork.CommitChanges();
            }
        }

        public void ChangeUserStatus(Guid userId, bool makeBlocked)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var userRepository = unitOfWork.GetRepository<User>();
                var user = userRepository.Single(o => o.UserId == userId);
                user.IsBlocked = makeBlocked;
                userRepository.Update(user);
                unitOfWork.CommitChanges();
            }
        }
    }
}
