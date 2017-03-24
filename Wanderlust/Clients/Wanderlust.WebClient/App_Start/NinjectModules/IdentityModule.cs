using Ninject.Modules;
using Ninject.Web.Common;
using Wanderlust.Business.Identity;
using Wanderlust.Business.Identity.Contracts;

namespace Wanderlust.WebClient.App_Start.NinjectModules
{
    public class IdentityModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserProvider>().To<UserProvider>().InRequestScope();
        }
    }
}