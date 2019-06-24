﻿using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class PhotoService : IPhotoService
    {
        private IHostingEnvironment _appEnvironment;

        public IUnitOfWork Db { get; set; }

        public PhotoService(IUnitOfWork uow, IHostingEnvironment appEnvironment)
        {
            Db = uow;
            _appEnvironment = appEnvironment;
        }

        public async Task<Photo> AddPhoto(IFormFile uploadedFile)
        {
            if (uploadedFile == null)
            {
                throw (new Exception("File not found!"));
            }
            
            // Validate for an image:
            if (!uploadedFile.IsImage())
            {
                throw (new Exception("File is not correct Image!"));
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
                File.Delete(_appEnvironment + photo.Url);
                Db.PhotoRepository.Delete(photo);
                await Db.SaveAsync();
            }
            
        }
    }
}