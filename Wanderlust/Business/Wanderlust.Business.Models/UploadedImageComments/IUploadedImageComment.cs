using System;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UploadedImageComments
{
    public interface IUploadedImageComment
    {
        int Id { get; set; }

        string Content { get; set; }

        DateTime DateCreated { get; set; }

        bool IsDeleted { get; set; }

        RegularUser Author { get; set; }

        UploadedImage UploadedImage { get; set; }
    }
}
