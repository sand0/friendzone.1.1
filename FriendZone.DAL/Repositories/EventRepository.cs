using Entities;
using Friendzone.Core.IRepositories;
using Friendzone.DAL.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Friendzone.DAL.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }
    }
}
