using System.Collections.Generic;

namespace Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<City> Cities { get; set; }
    }
}
