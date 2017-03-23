using System.Linq;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;

namespace Wanderlust.Business.Services.Contracts
{
    public interface IUploadedImageService
    {
        IQueryable<UploadedImage> GetAllImages();

        IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword);

        UploadedImage GetImageById(int id);

        void UploadImage(string imgDescription, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader);

        void CommentImage(int imgId, string comment, string authorId);
    }
}
