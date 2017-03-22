using System;
using System.ComponentModel.DataAnnotations;
using Wanderlust.Business.Common;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UploadedImageComments
{
    public class UploadedImageComment : IUploadedImageComment
    {
        public UploadedImageComment()
        {
            this.DateCreated = DateTime.Now;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(GlobalConstants.CommentMinLength)]
        [MaxLength(GlobalConstants.CommentMaxLength)]
        public string Content { get; set; }

        public DateTime DateCreated { get; set; }

        public bool IsDeleted { get; set; }

        public string AuthorId { get; set; }

        public virtual RegularUser Author { get; set; }

        public int UploadedImageId { get; set; }

        public virtual UploadedImage UploadedImage { get; set; }
    }
}
