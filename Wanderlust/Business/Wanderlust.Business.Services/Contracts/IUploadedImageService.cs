using System.Linq;
using Wanderlust.Business.Models.Locations;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUploadedImageService
    {
        IQueryable<UploadedImage> GetAllImages();

        IQueryable<UploadedImage> GetImages(int startAt, int count);

        IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword);

        IQueryable<UploadedImage> GetAllImagesByUser(string userId);

        IQueryable<UploadedImage> GetImagesByUser(string userId, int startAt, int count);

        UploadedImage GetImageById(int id);

        void UploadImage(string imgDescription, string country, string city, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader);

        void CommentImage(int imgId, string comment, string authorId);
    }
}
