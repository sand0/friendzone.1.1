using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Friendzone.Core.IRepositories
{
    public interface ICityRepository : IRepository<City>
    {
        IQueryable<City> GetByCountryId(int id);
    }
}
