using Microsoft.AspNet.Identity.EntityFramework;
using Wanderlust.Business.Models;

namespace Wanderlust.Business.Data
{
    public class WanderlustDbContext : IdentityDbContext<ApplicationUser>
    {
        public WanderlustDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static WanderlustDbContext Create()
        {
            return new WanderlustDbContext();
        }
    }
}
