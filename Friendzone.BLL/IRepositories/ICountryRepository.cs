using Entities;

namespace Friendzone.Core.IRepositories
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country GetByName(string name);
    }
}
