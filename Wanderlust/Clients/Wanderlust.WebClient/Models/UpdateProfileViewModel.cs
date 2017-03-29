using System.ComponentModel.DataAnnotations;

namespace Wanderlust.WebClient.Models
{
    public class UpdateProfileViewModel
    {
        [Required]
        [StringLength(500, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 5)]
        [Display(Name = "Description")]
        public string UserInfo { get; set; }
    }
}