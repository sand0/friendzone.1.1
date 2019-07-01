using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    //[ApiController]
    public class EventController : Controller
    {
        private IEventService _eventService;
        private IUserService _userService;
        private IProfileService _profileService;
        private IMapper _mapper;


        public EventController(
            IEventService eventSrv,
            IUserService userSrv,
            IProfileService profileSrv,
            IMapper mapper)
        {
            _eventService = eventSrv;
            _userService = userSrv;
            _profileService = profileSrv;
            _mapper = mapper;
        }

        // For test
        [HttpGet("/[controller]/page{page}")]
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            int count = _eventService.Events().Count();
            var items = _eventService.Events(
                skip: (page - 1) * pageSize,
                take: pageSize
                )
                .AsEnumerable();

            ViewData["take"] = pageSize;
            ViewData["page"] = page;

            return View(items);
        }

        // API endpoints:

        [HttpGet]
        public IActionResult Get(int page = 1, int pageSize = 20)
        {
            int count = _eventService.Events().Count();
            var items = _eventService.Events(
                skip: (page - 1) * pageSize, 
                take: pageSize
                )
                .AsEnumerable();

            return Ok(items);
        }

        [HttpGet("My")]
        public async Task<IActionResult> MyEvents(int page = 1, int pageSize = 20)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            Expression<Func<Event, bool>> filter = (e => e.OwnerUserId == currentUser.Id);

            int count = _eventService.Events(filter: filter).Count();

            var items = _eventService.Events(
                filter: filter,
                skip: (page - 1) * pageSize, 
                take: pageSize
                )
                .AsEnumerable();

            return Ok(items);
        }

        [HttpGet("IGo")]
        public async Task<IActionResult> IGoEvents(int page = 1, int pageSize = 20)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);

            var items = _eventService.UserEvents(currentUser.Id);

            return Ok(items);
        }

        [HttpGet("{id:int}/details")]
        public IActionResult Get(int id)
        {
            EventDTO ev = _eventService.Events(id);
            EventDetailsViewModel model = _mapper.Map<EventDTO, EventDetailsViewModel>(ev);

            model.Owner = _mapper.Map<ProfileDTO, UserProfilePreviewModel>(_profileService.GetById(model.OwnerUserId));

            model.Visitors = _mapper.Map<List<ProfileDTO>, List<UserProfilePreviewModel>>(ev.Visitors
                .Select(x => _profileService.GetById(x)).ToList());
            
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

        [HttpPost("[action]")]
        public async Task<IActionResult> VisitEvent(int eventId)
        {
            User currentUser = await _userService.GetCurrentUserAsync(HttpContext);
            await _eventService.AddUserToEventAsync(currentUser.Id, eventId);
            return Ok();
        }
    }
}