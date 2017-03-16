using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;

namespace Wanderlust.WebClient.App_Start.NinjectModules
{
    public class ServicesModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x =>
                x.From("Wanderlust.Business.Services")
                .SelectAllClasses()
                .BindDefaultInterface()
                .Configure(c => c.InRequestScope()));
        }
    }
}