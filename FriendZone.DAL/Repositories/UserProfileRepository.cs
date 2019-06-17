using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;

namespace Friendzone.DAL.Repositories
{
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        public UserProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}
