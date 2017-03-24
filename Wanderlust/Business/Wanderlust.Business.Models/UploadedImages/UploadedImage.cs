using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.UploadedImageComments;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UploadedImages
{
    public class UploadedImage : IUploadedImage
    {
        private ICollection<UploadedImageComment> comments;

        public UploadedImage()
        {
            this.comments = new HashSet<UploadedImageComment>();
            this.DateUploaded = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [MaxLength(GlobalConstants.UploadedImageDescriptionMaxLength)]
        public string Description { get; set; }

        public DateTime DateUploaded { get; set; }

        [Required]
        public string ThumbnailSrc { get; set; }

        [Required]
        public string OriginalSrc { get; set; }

        public bool IsDeleted { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        //public int CountryId { get; set; }

        //public virtual Country Country { get; set; }

        //public int CityId { get; set; }

        //public virtual City City { get; set; }

        public string UploaderId { get; set; }

        public virtual RegularUser Uploader { get; set; }

        public virtual ICollection<UploadedImageComment> Comments
        {
            get
            {
                return this.comments;
            }
            set
            {
                this.comments = value;
            }
        }

        public int LikesCount { get; set; }
    }
}
