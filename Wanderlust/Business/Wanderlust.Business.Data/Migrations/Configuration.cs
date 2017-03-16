namespace Wanderlust.Business.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<Wanderlust.Business.Data.WanderlustDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Wanderlust.Business.Data.WanderlustDbContext";
        }

        protected override void Seed(Wanderlust.Business.Data.WanderlustDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
