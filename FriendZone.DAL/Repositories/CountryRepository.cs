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

        public Country GetByName(string name) => Entities.Where(c => c.Name.ToUpper() == name.ToUpper()).FirstOrDefault();
    }
}
