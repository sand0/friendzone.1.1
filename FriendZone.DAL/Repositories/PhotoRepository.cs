using Entities;
using Friendzone.DAL.Data;
using Friendzone.DAL.Repositories;
using FriendZone.DAL.Interfaces;

namespace FriendZone.DAL.Repositories
{
    public class PhotoRepository : Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(AppDbContext context) : base(context)
        {
        }
    }
}
