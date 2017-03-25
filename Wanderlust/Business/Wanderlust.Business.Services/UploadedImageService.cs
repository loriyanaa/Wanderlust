using Bytes2you.Validation;
using System;
using System.Collections.Generic;
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
        private readonly IEfRepository<UploadedImage> imagesRepo;
        private readonly IEfRepository<RegularUser> usersRepo;
        private readonly IEfUnitOfWork uow;

        public UploadedImageService(IEfRepository<UploadedImage> imagesRepo, IEfRepository<RegularUser> usersRepo,
            IEfUnitOfWork uow)
        {
            Guard.WhenArgument(imagesRepo, "imagesRepo").IsNull().Throw();
            Guard.WhenArgument(usersRepo, "usersRepo").IsNull().Throw();
            Guard.WhenArgument(uow, "uow").IsNull().Throw();

            this.imagesRepo = imagesRepo;
            this.usersRepo = usersRepo;
            this.uow = uow;
        }

        public IQueryable<UploadedImage> GetAllImages()
        {
            return this.imagesRepo.All().Where(i => !i.IsDeleted).OrderBy(i => i.DateUploaded);
        }

        public IQueryable<UploadedImage> GetImages(int startAt, int count)
        {
            return this.imagesRepo.All().Where(i => !i.IsDeleted).OrderBy(i => i.DateUploaded).Skip(startAt).Take(count);
        }

        public IQueryable<UploadedImage> GetAllImagesByUser(string userId)
        {
            return this.imagesRepo.All().Where(i => !i.IsDeleted && i.UploaderId == userId);
        }

        public IQueryable<UploadedImage> GetImagesByUser(string userId, int startAt, int count)
        {
            return this.imagesRepo.All().Where(i => !i.IsDeleted && i.UploaderId == userId).OrderBy(i => i.DateUploaded).Skip(startAt).Take(count);
        }

        public UploadedImage GetImageById(int id)
        {
            return this.imagesRepo.GetById(id);
        }

        public void CommentImage(int imgId, string comment, string authorId)
        {
            var image = this.imagesRepo.GetById(imgId);
            image.Comments.Add(new UploadedImageComment() { AuthorId = authorId, Content = comment });
            using (var uow = this.uow)
            {
                this.imagesRepo.Update(image);
                uow.SaveChanges();
            }
        }

        public void UploadImage(string ImgDescription, string country, string city, string thumbnailImgUrl, string originalImgUrl, RegularUser uploader)
        {
            var image = new UploadedImage()
            {
                Description = ImgDescription,
                Country = country,
                City = city,
                ThumbnailSrc = thumbnailImgUrl,
                OriginalSrc = originalImgUrl,
                DateUploaded = DateTime.Now,
                IsDeleted = false,
                Uploader = uploader,
                UploaderId = uploader.Id
            };

            using (var uow = this.uow)
            {
                uploader.UploadedImages.Add(image);
                uow.SaveChanges();
            }
        }
    }
}
