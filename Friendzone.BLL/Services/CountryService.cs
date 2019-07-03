using Entities;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class CountryService : ICountryService
    {
        public IUnitOfWork Db { get; set; }

        public CountryService(IUnitOfWork uow)
        {
            Db = uow;
        }


        public IEnumerable<Country> GetCountries() => Db.CountryRepository.Get();

        public Country GetByName(string name) => Db.CountryRepository.Get(c => c.Name == name).FirstOrDefault();

        public async Task<OperationDetails> CreateCountryAsync(Country country)
        {
            if (Db.CountryRepository.Get(c => c.Name == country.Name).Count() != 0)
            {
                return new OperationDetails ( false, "Country is already exist", "" );
            }
            Db.CountryRepository.Create(country);
            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> EditCountryAsync(Country country)
        {
            if (country.Id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }

            Country oldCountry = Db.CountryRepository.Get(country.Id);
            if (oldCountry == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            oldCountry.Name = country.Name;

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Country country = Db.CountryRepository.Get(id);
            if (country == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            var result = Db.CountryRepository.Delete(country);
            await Db.SaveAsync();
            return new OperationDetails(result, "Not found", "");
        }
    }
}
