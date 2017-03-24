namespace Wanderlust.Business.Identity.Contracts
{
    public interface IUserProvider
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}
