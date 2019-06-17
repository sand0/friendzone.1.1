using Entities;
using Friendzone.DAL.Data;
using Friendzone.DAL.Repositories;
using Friendzone.Core.IRepositories;

namespace Friendzone.DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
