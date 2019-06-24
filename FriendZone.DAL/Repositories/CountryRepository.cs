using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;
using System.Linq;

namespace Friendzone.DAL.Repositories
{
    public class CountryRepository : Repository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
        }

    }
}
