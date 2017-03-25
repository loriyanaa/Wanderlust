using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Data
{
    public class WanderlustEfDbContext : IdentityDbContext<ApplicationUser>, IWanderlustEfDbContext
    {
        public WanderlustEfDbContext()
            : base("WanderlustDb", throwIfV1Schema: false)
        {
        }

        public static WanderlustEfDbContext Create()
        {
            return new WanderlustEfDbContext();
        }

        IDbSet<T> IWanderlustEfDbContext.Set<T>()
        {
            return base.Set<T>();
        }

        void IWanderlustEfDbContext.SaveChanges()
        {
            base.SaveChanges();
        }

        public virtual IDbSet<RegularUser> RegularUsers { get; set; }

        public virtual IDbSet<UploadedImage> UploadedImages { get; set; }
    }
}
