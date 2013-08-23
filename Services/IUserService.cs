using DomainModels;

namespace Services
{
    public interface IUserService:IServiceBase<User>
    {
        bool AddNewUser(User user);
        void UpdateUser(User user);
        bool IsUsedEmail(string email);
        bool VerifyUserPassword(string email, string password);
    }
}
