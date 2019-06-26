using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Friendzone.Core.IServices
{
    public interface IEventService
    {
        IEnumerable<EventDTO> Events();
        EventDTO Events(int id);

        Task<OperationDetails> CreateEventAsync(EventDTO ev);
        Task<OperationDetails> EditEventAsync(EventDTO ev);
        Task<OperationDetails> DeleteAsync(int id);

        List<string> GetCategoriesForEvent(Event e);
    }
}
