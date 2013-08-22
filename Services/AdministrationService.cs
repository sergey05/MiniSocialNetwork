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
        private readonly IUnitOfWork _unitOfWork;

        public AdministrationService(IUnitOfWork unitOfWork): base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void MakeAdmin(Guid userId)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = userRepository.Single(o => o.UserId == userId);
            user.Role = Role.Admin;
            userRepository.Update(user);
            _unitOfWork.CommitChanges();
        }

        public void ChangeUserStatus(Guid userId, bool makeBlocked)
        {
            var userRepository = _unitOfWork.GetRepository<User>();
            var user = userRepository.Single(o => o.UserId == userId);
            user.IsBlocked = makeBlocked;
            userRepository.Update(user);
            _unitOfWork.CommitChanges();
        }
    }
}
