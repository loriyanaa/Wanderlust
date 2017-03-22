namespace Wanderlust.Business.Services.Contracts
{
    public interface IRegistrationService
    {
        void CreateUser(string userId, string username, string email);
    }
}
