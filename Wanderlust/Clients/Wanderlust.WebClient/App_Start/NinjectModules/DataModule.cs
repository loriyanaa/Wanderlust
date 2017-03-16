using Ninject.Modules;
using Ninject.Extensions.Conventions;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Data.Repositories;
using Ninject.Web.Common;
using Wanderlust.Business.Data;

namespace Wanderlust.WebClient.App_Start.NinjectModules
{
    public class DataModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind(x => x.From("Wanderlust.Business.Models").SelectAllClasses().BindDefaultInterface());
            this.Bind(typeof(IEntityFrameworkRepository<>)).To(typeof(EntityFrameworkRepository<>));
            this.Bind<IWanderlustDbContext>().To<WanderlustDbContext>().InRequestScope();
            this.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
    }
}