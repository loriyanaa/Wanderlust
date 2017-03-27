using System.ComponentModel.DataAnnotations;
using Wanderlust.Business.Models.Users.Contracts;

namespace Wanderlust.Business.Models.Users
{
    public class Admin
    {
        [Key]
        public string Id { get; set; }

        public string AdminStuff { get; set; }
    }
}
