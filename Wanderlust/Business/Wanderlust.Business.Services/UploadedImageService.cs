using Bytes2you.Validation;
using System;
using System.Linq;
using Wanderlust.Business.Data.Contracts;
using Wanderlust.Business.Models.UploadedImageComments;
using Wanderlust.Business.Models.UploadedImages;
using Wanderlust.Business.Models.Users;
using Wanderlust.Business.Services.Contracts;

namespace Wanderlust.Business.Services
{
    public class UploadedImageService : IUploadedImageService
    {
        private readonly IEfRepository<UploadedImage> repo;
        private readonly IEfUnitOfWork uow;

        public UploadedImageService(IEfRepository<UploadedImage> repo, IEfUnitOfWork uow)
        {
            Guard.WhenArgument(repo, "uploadedImageRepo").IsNull().Throw();
            Guard.WhenArgument(uow, "unitOfWork").IsNull().Throw();

            this.repo = repo;
            this.uow = uow;
        }

        public IQueryable<UploadedImage> GetAllImages()
        {
            return this.repo.All().Where(i => !i.IsDeleted).OrderBy(i => i.DateUploaded);
        }

        public IQueryable<UploadedImage> GetImagesWithTitle(string titleKeyword)
        {
            return this.repo.All().Where(i => !i.IsDeleted && i.Description.Contains(titleKeyword));
        }

        public UploadedImage GetImageById(int id)
        {
            return this.repo.GetById(id);
        }

        public void CommentImage(int imgId, string comment, string authorId)
        {
            var image = this.repo.GetById(imgId);
            image.Comments.Add(new UploadedImageComment() { AuthorId = authorId, Content = comment });
            using (var uow = this.uow)
            {
                this.repo.Update(image);
                uow.SaveChanges();
            }
        }

        public void UploadImage(string ImgDescription, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader)
        {
            var image = new UploadedImage()
            {
                Description = ImgDescription,
                ThumbnailSrc = thumbnailImgUrl,
                OriginalSrc = originalImgUrl,
                DateUploaded = DateTime.Now,
                IsDeleted = false
            };

            using (var uow = this.uow)
            {
                uploader.UploadedImages.Add(image);
                uow.SaveChanges();
            }
        }
    }
}
