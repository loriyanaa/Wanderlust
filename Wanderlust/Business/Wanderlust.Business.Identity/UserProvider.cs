using Microsoft.AspNet.Identity;
using System.Web;
using Wanderlust.Business.Identity.Contracts;

namespace Wanderlust.Business.Identity
{
    public class UserProvider : IUserProvider
    {
        public string GetUserId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}
