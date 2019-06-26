using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Entities;
using Friendzone.Core.DTO;
using Friendzone.Core.IServices;
using Friendzone.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Friendzone.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IEventService _eventService;
        private IMapper _mapper;
        
        public EventController(IEventService eventSrv, IMapper mapper)
        {
            _eventService = eventSrv;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_eventService.Events());
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            EventDTO ev = _eventService.Events(id);
            EventDetailsViewModel model = _mapper.Map<EventDTO, EventDetailsViewModel>(ev);

            
            return Ok(model);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Edit(EventEditViewModel model)
        {
            EventDTO eventDTO = _mapper.Map<EventEditViewModel, EventDTO>(model);

            var result = model.Id == 0 ?
                await _eventService.CreateEventAsync(eventDTO) :
                await _eventService.EditEventAsync(eventDTO);
                       
            if (result.Succedeed)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id != 0)
            {
                var result = await _eventService.DeleteAsync(id);
                if (result.Succedeed)
                {
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}