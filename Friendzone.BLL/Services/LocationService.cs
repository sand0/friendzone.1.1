using Entities;
using Friendzone.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.Services
{
    public class LocationService
    {
        public IUnitOfWork Db { get; set; }

        public LocationService(IUnitOfWork uow)
        {
            Db = uow;
        }

        public IEnumerable<Country> GetCountries() => Db.CountryRepository.All();

        public IEnumerable<City> GetCitiesByCountryId(int id) => Db.CityRepository.Filrer(c => c.CountryId == id);


        Country CreateCountry(Country country) =>
            Db.CountryRepository.Filrer(c => c.Name.ToUpper() == country.Name.ToUpper()).FirstOrDefault()
            ??
            Db.CountryRepository.Create(country);
            

        public async Task<City> CreateCity(City city)
        {
            city.Country = CreateCountry(city.Country);

            var result = GetCitiesByCountryId(city.Country.Id)
                .Where(c => c.Name.ToUpper() == city.Name.ToUpper())
                .FirstOrDefault();

            if (result == null)
            {
                result = Db.CityRepository.Create(city);
                await Db.SaveAsync();
            }
            return result;
        }
    }
}
