using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface IEventService
    {
        IQueryable<EventDTO> Events(
            Expression<Func<Event, bool>> filter = null,
            Func<IQueryable<Event>, IOrderedQueryable<Event>> orderBy = null,
            int? skip = null,
            int? take = null
            );
        EventDTO Events(int id);
        IEnumerable<EventDTO> UserEvents(string userId);

        Task<OperationDetails> CreateEventAsync(EventDTO ev);
        Task<OperationDetails> EditEventAsync(EventDTO ev);
        Task<OperationDetails> DeleteAsync(int id);

        Task<OperationDetails> AddUserToEventAsync(string profileId, int eventId);

    }
}
