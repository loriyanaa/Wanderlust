using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Locations.Contracts;

namespace Wanderlust.Business.Models.Locations
{
    public class City : ICity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }       
    }
}
