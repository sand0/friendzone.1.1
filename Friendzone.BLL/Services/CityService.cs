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
    public class CityService : ICityService
    {
        public IUnitOfWork Db { get; set; }

        public CityService(IUnitOfWork uow)
        {
            Db = uow;
        }


        public IQueryable<City> GetCitiesByCountryId(int id) => Db.CityRepository.GetByCountryId(id);

        public IQueryable<City> GetAll() => Db.CityRepository.All();

        public async Task<OperationDetails> CreateCityAsync(City city)
        {
            var counry = Db.CountryRepository.Get(city.CountryId);

            if (counry == null)
            {
                return new OperationDetails(false, $"Bad country Id: {city.CountryId}", "");
            }

            city.Country = counry;

            var result = GetCitiesByCountryId(city.Country.Id)
                .Where(c => c.Name.ToUpper() == city.Name.ToUpper())
                .FirstOrDefault();

            if (result != null)
            {
                return new OperationDetails(false, "City is already exist!", "" );
            }

            Db.CityRepository.Create(city);
            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> EditCityAsync(City city)
        {
            if (city.Id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            // Build new entity
            var counry = Db.CountryRepository.Get(city.CountryId);
            if (counry == null)
            {
                return new OperationDetails(false, $"Bad country Id: {city.CountryId}", "");
            }
            city.Country = counry;

            // Find old entity
            City oldCity = Db.CityRepository.Get(city.Id);
            if (oldCity == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            // Update
            oldCity.Name = city.Name;
            oldCity.CountryId = city.CountryId;

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> DeleteCityAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            City city = Db.CityRepository.Get(id);
            if (city == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            var result = Db.CityRepository.Delete(city);
            await Db.SaveAsync();
            return new OperationDetails(result, "", "");
        }
    }
}
