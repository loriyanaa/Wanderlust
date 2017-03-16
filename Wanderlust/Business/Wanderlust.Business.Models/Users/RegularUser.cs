using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.Users.Contracts;

namespace Wanderlust.Business.Models.Users
{
    public class RegularUser : IRegularUser
    {
        //private ICollection<UploadedImage> uploadedImages;

        private ICollection<RegularUser> followers;

        private ICollection<RegularUser> following;

        public RegularUser()
        {
            this.followers = new HashSet<RegularUser>();
            this.following = new HashSet<RegularUser>();
            //this.uploadedImages = new HashSet<UploadedImage>();
        }

        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [MinLength(GlobalConstants.NameMinLength)]
        [MaxLength(GlobalConstants.NameMaxLength)]
        public string Username { get; set; }

        public string Email { get; set; }

        public string AvatarUrl { get; set; }

        public string FacebookProfile { get; set; }

        public string UserInfo { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<RegularUser> Followers
        {
            get
            {
                return this.followers;
            }
            set
            {
                this.followers = value;
            }
        }

        public virtual ICollection<RegularUser> Following
        {
            get
            {
                return this.following;
            }
            set
            {
                this.following = value;
            }
        }

        //public virtual ICollection<UploadedImage> UploadedImages
        //{
        //    get
        //    {
        //        return this.uploadedImages;
        //    }
        //    set
        //    {
        //        this.uploadedImages = value;
        //    }
        //}
    }
}
