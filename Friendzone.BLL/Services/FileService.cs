using Entities;
using Friendzone.Core.IRepositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class FileService
    {
        private IHostingEnvironment _appEnvironment;

        public IUnitOfWork Db { get; set; }
        
        public FileService(IUnitOfWork uow, IHostingEnvironment appEnvironment)
        {
            Db = uow;
            _appEnvironment = appEnvironment;
        }

        async Task<Photo> AddPhoto(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                throw(new Exception("File not found!"));
            }
            // TODO: image validation and convertation

            string path = "/Files/" + uploadedFile.FileName;

            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
                await uploadedFile.CopyToAsync(fileStream);
            }

            Photo photo = new Photo { Url = path };
            Db.PhotoRepository.Create(photo);

            await Db.SaveAsync();
            

            return photo;
        }
    }
}
