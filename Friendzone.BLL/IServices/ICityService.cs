using Entities;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface ICityService
    {
        City Get(int id);
        IQueryable<City> GetCitiesByCountryId(int id);
        IQueryable<City> GetAll();
        Task<OperationDetails> CreateCityAsync(City city);
        Task<OperationDetails> EditCityAsync(City city);
        Task<OperationDetails> DeleteCityAsync(int id);

    }
}
