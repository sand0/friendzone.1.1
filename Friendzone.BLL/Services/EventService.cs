using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Friendzone.Core.Services
{
    public class EventService : IEventService
    {
        private IMapper _mapper;
        public IUnitOfWork Db { get; set; }

        public EventService(IUnitOfWork uow, IMapper mapper)
        {
            _mapper = mapper;
            Db = uow;
        }


        public IEnumerable<Event> Events() => Db.EventRepository.All();

        public async Task<OperationDetails> CreateEventAsync(EventDTO eventDto)
        {
            if (eventDto.Id != 0)
            {
                return new OperationDetails(false, $"Invalid id value: {eventDto.Id}", "Id");
            }
            Event ev = _mapper.Map<EventDTO, Event>(eventDto);

            // Create event
            Event newEvent = Db.EventRepository.Create(ev);

            // Add selected Categories
            if (eventDto.CategoriyIds.Count > 0)
            {
                newEvent.EventCategory = new List<EventCategory>();
                foreach (var c in eventDto.CategoriyIds)
                {
                    newEvent.EventCategory.Add(new EventCategory { CategoryId = c, Event = newEvent });
                }

            }

            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }

        public async Task<OperationDetails> EditEventAsync(EventDTO ev)
        {
            throw new NotImplementedException();
        }

        public async Task<OperationDetails> DeleteAsync(int id)
        {
            if (id == 0)
            {
                return new OperationDetails(false, "Id field is '0'", "");
            }
            Event ev = Db.EventRepository.Get(id);
            if (ev == null)
            {
                return new OperationDetails(false, "Not found", "");
            }

            var result = Db.EventRepository.Delete(ev);
            await Db.SaveAsync();
            return new OperationDetails(result, "Not found", "");
        }
    }
}
