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
        IEnumerable<Event> Events();
        Event Events(int id);
        Task<OperationDetails> CreateEventAsync(EventDTO ev);
        Task<OperationDetails> EditEventAsync(EventDTO ev);
        Task<OperationDetails> DeleteAsync(int id);
    }
}
