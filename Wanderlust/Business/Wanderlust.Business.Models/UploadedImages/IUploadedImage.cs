using System;
using System.Collections.Generic;
using Wanderlust.Business.Models.Locations;
using Wanderlust.Business.Models.UploadedImageComments;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Models.UploadedImages
{
    public interface IUploadedImage
    {
        int Id { get; set; }

        string Description { get; set; }

        DateTime DateUploaded { get; set; }

        int CountryId { get; set; }

        Country Country { get; set; }

        int CityId { get; set; }

        City City { get; set; }

        bool IsDeleted { get; set; }

        string ThumbnailSrc { get; set; }

        string OriginalSrc { get; set; }

        string UploaderId { get; set; }

        RegularUser Uploader { get; set; }

        ICollection<UploadedImageComment> Comments { get; set; }

        int LikesCount { get; set; }
    }
}
