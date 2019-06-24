using Entities;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface ICountryService
    {
        IEnumerable<Country> GetCountries();
        Country GetByName(string name);
        Task<OperationDetails> CreateCountryAsync(Country country);
        Task<OperationDetails> EditCountryAsync(Country country);
        Task<OperationDetails> DeleteAsync(int id);
    }
}
