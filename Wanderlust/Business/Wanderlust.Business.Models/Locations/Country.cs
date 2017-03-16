using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Locations.Contracts;

namespace Wanderlust.Business.Models.Locations
{
    public class Country : ICountry
    {
        private ICollection<City> cities;

        public Country()
        {
            this.cities = new HashSet<City>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities
        {
            get
            {
                return this.cities;
            }
            set
            {
                this.cities = value;
            }
        }
    }
}
