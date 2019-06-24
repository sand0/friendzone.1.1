using System.Linq;
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

        public IQueryable<City> GetByCountryId(int id)
        {
            return Entities.Where(c => c.CountryId == id);
        }
    }
}
