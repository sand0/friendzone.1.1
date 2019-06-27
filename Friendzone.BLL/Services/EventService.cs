﻿using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.Infrastructure;
using Friendzone.Core.IRepositories;
using Friendzone.Core.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;

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


        public IEnumerable<EventDTO> Events()
        {
            var events = Db.EventRepository.All().AsEnumerable();
            return _mapper.Map<IEnumerable<Event>, IEnumerable<EventDTO>>(events);
        }
        

        public EventDTO Events(int id)
        {
            var ev = Db.EventRepository
                .Get(e => e.Id == id, null, "Owner,City,EventCategory,Visitors")
                .FirstOrDefault();

            EventDTO eventDTO = _mapper.Map<Event, EventDTO>(ev);
            eventDTO.CategoryNames = ev.EventCategory
                .Select(x => Db.CategoryRepository.Get(x.CategoryId).Name).ToList();
            eventDTO.Visitors = ev.Visitors
                .Select(x => x.UserProfileId).ToList();

            //var eventDTO = _mapper.Map<Event, EventDTO>(ev, opt => 
            //{ opt.AfterMap((src, dest) 
            //    => {
            //        dest.CategoryNames = src.EventCategory
            //            .Select(x => Db.CategoryRepository.Get(x.CategoryId).Name).ToList();
            //        dest.Visitors = src.Visitors
            //            .Select(val => val.UserProfileId).ToList();
            //    });
            //});

            return eventDTO;
        }


        public async Task<OperationDetails> AddUserToEventAsync(string profileId, int eventId)
        {
            var ev = Db.EventRepository
                .Get(e => e.Id == eventId, null, "Visitors")
                .FirstOrDefault();

            if (ev == null)
            {
                return new OperationDetails(false, "Event not found!", "eventId");
            }

            if (ev.Visitors == null)
            {
                ev.Visitors = new List<EventUserProfile>();
            }

            ev.Visitors.Add(new EventUserProfile { EventId = eventId, UserProfileId = profileId});
            await Db.SaveAsync();

            return new OperationDetails(true, "", "");
        }


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

        public async Task<OperationDetails> EditEventAsync(EventDTO eventDto)
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
