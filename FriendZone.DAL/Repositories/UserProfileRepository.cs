using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Friendzone.DAL.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }

        public UserProfile GetProfileWithAllFields(int id)
        {
            return Entities.Where(p => p.Id == id)
                .Include(p => p.User)
                .Include(p => p.City).ThenInclude(c => c.Country)
                .Include(p => p.Avatar)
                .FirstOrDefault();                    
        }
    }
}
