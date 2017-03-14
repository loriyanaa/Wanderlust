using Microsoft.AspNet.Identity.EntityFramework;

namespace Wanderlust.Business.Models.UserRoles
{
    public class Role : IdentityRole
    {
        public Role() : base() { }

        public Role(string name) : base(name) { }

        public string Description { get; set; }
    }
}
