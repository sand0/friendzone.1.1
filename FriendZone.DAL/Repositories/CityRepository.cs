using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;

namespace Friendzone.DAL.Repositories
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {
        }
    }
}
