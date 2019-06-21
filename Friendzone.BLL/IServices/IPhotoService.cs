using Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface IPhotoService
    {
        Task<Photo> AddPhoto(IFormFile uploadedFile);
        Task Delete(int id);
    }
}
