using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private IHostingEnvironment _appEnvironment;

        public IUnitOfWork Db { get; set; }



        public PhotoService(
            IUnitOfWork uow, 
            IHostingEnvironment appEnvironment
            )
        {
            Db = uow;
            _appEnvironment = appEnvironment;

        }


        public async Task<Photo> AddPhoto(IFormFile uploadedFile)
        {
            if (!IsValidImage(uploadedFile))
            {
                throw (new Exception("Bad file!"));
            }

            string path = "/files/" + uploadedFile.FileName;
            
            // TODO: image resizing ...
            //
            //
            //

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            Photo photo = new Photo { Url = path };
            Db.PhotoRepository.Create(photo);

            await Db.SaveAsync();

            return photo;
        }

        public async Task Delete(int id)
        {
            var photo = Db.PhotoRepository.Get(id);
            if (photo != null)
            {
                try
                {
                    File.Delete(_appEnvironment + photo.Url);
                }
                finally
                {
                    Db.PhotoRepository.Delete(photo);
                    await Db.SaveAsync();
                }
            }
            
        }


        private bool IsValidImage(IFormFile file)
        {
            if (file == null)
            {
                return false;
                //throw (new Exception("File not found!"));
            }

            if (!file.IsImage())
            {
                return false;
                //throw (new Exception("File is not correct Image!"));
            }
            return true;
        }


        // We can use this one to resize and save image:
        // need to customize params for our situation...
        //
        public void ResizeAndSaveImage(IFormFile originalImage, int[] widths, string originalImageFilePath, string extension)
        {
            byte[] imgData;
            using (var reader = new BinaryReader(originalImage.OpenReadStream()))
            {
                imgData = reader.ReadBytes((int)originalImage.Length);
            }

            var filePath = originalImageFilePath.Substring(0, originalImageFilePath.Length - extension.Length);

            foreach (var width in widths)
            {
                var resizedImageFilePath = filePath + "_" + width + extension;

                byte[] resizedImageBytes = this.Resize(imgData, width);

                MemoryStream ms = new MemoryStream(resizedImageBytes);
                Image resizedImage = Image.FromStream(ms);
                
                //resizedImage.Save(resizedImageFilePath);
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + resizedImageFilePath, FileMode.Create))
                {
                    resizedImage.Save(fileStream, ImageFormat.Jpeg);
                }
            }
        }

        public byte[] Resize(byte[] originalImage, int width)
        {
            using (var originalImageStream = new MemoryStream(originalImage))
            {
                using (var resultImage = new MemoryStream())
                {
                    using (var imageFactory = new ImageFactory())
                    {
                        var createdImage = imageFactory
                                .Load(originalImageStream);

                        if (createdImage.Image.Width > width)
                        {
                            createdImage = createdImage
                                .Resize(new ResizeLayer(new Size(width, 0), ResizeMode.Max));
                        }

                        createdImage
                            .Format(new JpegFormat { /* Quality = WebApplicationConstants.ImageQuality*/ })
                            .Save(resultImage);
                    }

                    return resultImage.GetBuffer();
                }
            }
        }
    }

}
