using EventsHubCatalogAPI.Data;
using EventsHubCatalogAPI.Domain;
using EventsHubCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EventsHubCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class EventController : ControllerBase
    {
        private readonly EventContext _context;
        private readonly IConfiguration _config;
        public EventController(EventContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> CategoryTypes()
        {
            var types = await _context.CategoryTypes.ToListAsync();
            return Ok(types);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> OrganizerTypes()
        {
            var organizers = await _context.OrganizerTypes.ToListAsync();
            return Ok(organizers);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var eventsCount = _context.Events.LongCountAsync();
            var events = await _context.Events
                            .OrderBy(c => c.Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();
            events = ChangePictureUrl(events);

            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = events.Count,
                Data = events,
                Count = eventsCount.Result
            };
            return Ok(model);
        }

        private List<EventType> ChangePictureUrl(List<EventType> events)
        {
           // events.ForEach(e => e.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalBaseUrl"]));
            
            foreach(EventType eventType in events)
            {
                eventType.PictureUrl = eventType.PictureUrl.Replace("http://externalcatalogbaseurltobereplaced", _config["ExternalBaseUrl"]);
            }
            
            return events;
        }

        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Events(
           [FromQuery] int? categoryTypeId,
           [FromQuery] int? organizerTypeId,
           [FromQuery] int pageIndex = 0,
           [FromQuery] int pageSize = 6)
        {
            var query = (IQueryable<EventType>)_context.Events;
            if (categoryTypeId.HasValue)
            {
                query = query.Where(c => c.CategoryTypeId == categoryTypeId.Value);
            }
            if (organizerTypeId.HasValue)
            {
                query = query.Where(c => c.OrganizerTypeId == organizerTypeId.Value);
            }
            var itemsCount = query.LongCountAsync();
            var items = await query
                            .OrderBy(c => c.Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedEventsViewModel
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Data = items,
                Count = itemsCount.Result
            };

            return Ok(model);
        }
    }
}
