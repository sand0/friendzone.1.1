using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;

namespace Friendzone.DAL.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
