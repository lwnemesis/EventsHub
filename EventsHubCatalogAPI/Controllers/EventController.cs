using EventsHubCatalogAPI.Data;
using EventsHubCatalogAPI.Domain;
using EventsHubCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var brands = await _context.OrganizerTypes.ToListAsync();
            return Ok(brands);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Events(
            [FromQuery] int pageIndex = 0, [FromQuery] int pageSize = 6)
        {
            var itemsCount = _context.Events.LongCountAsync();
            var items = await _context.Events
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

        private List<EventType> ChangePictureUrl(List<EventType> items)
        {
            items.ForEach(item => item.PictureUrl = item.PictureUrl
                                        .Replace("http://externalcatalogbaseurltobereplaced",
                                        _config["ExternalBaseUrl"]));
            return items;
        }
    }
}

