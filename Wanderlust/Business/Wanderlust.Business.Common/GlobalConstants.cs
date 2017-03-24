namespace Wanderlust.Business.Common
{
    public class GlobalConstants
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;

        public const int MinAge = 18;
        public const int MaxAge = 100;

        public const int CommentMinLength = 5;
        public const int CommentMaxLength = 500;

        public const int UploadedImageDescriptionMaxLength = 500;

        public const int ThumbnailImageSize = 500;
        public const int LargeImageSize = 700;

        public const int ThumbnailImageQualityPercentage = 80;
        public const int OriginalImageQualityPercentage = 100;

        public const string FailedUploadMessage = "Unfortunately, your uploading  has failed.\r\nPlease, try again later.";

        public const string WanderlustUrl = "http://www.dev.wanderlust.com/";
        public const string ContentUploadedWanderlustThumbnailsRelPath = "Content/Uploaded/Images/Thumbnails/";
        public const string ContentUploadedWanderlustOriginalsRelPath = "Content/Uploaded/Images/Originals/";
        public const string ContentUploadedProfilesRelPath = "Content/Uploaded/Profiles/";

        public const int ImagesInitial = 6;
    }
}
