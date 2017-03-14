using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Data
{
    public class WanderlustDbContext : IdentityDbContext<ApplicationUser>, IWanderlustDbContext
    {
        public WanderlustDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static WanderlustDbContext Create()
        {
            return new WanderlustDbContext();
        }

        IDbSet<T> IWanderlustDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        void IWanderlustDbContext.SaveChanges()
        {
            base.SaveChanges();
        }
    }
}
