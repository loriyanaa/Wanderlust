using System.Data.Entity;
using Wanderlust.Business.Data;
using Wanderlust.Business.Data.Migrations;

namespace Wanderlust.WebClient.App_Start
{
    public class DbConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<WanderlustEfDbContext, Configuration>());
            WanderlustEfDbContext.Create().Database.Initialize(true);
        }
    }
}