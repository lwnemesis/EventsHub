using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Models;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class EventController : Controller
    {
        private readonly ICatalogService _service;
     
           
        public EventController(ICatalogService service)
        {
            _service = service;
        }
       
            public async Task<IActionResult> Index(int? page, int? organizerFilterApplied, int? typesFilterApplied)
        {
            var itemsOnPage = 10;
            EventsCatalog events = null;
            while (events == null)
            {
                events = await _service.GetEventsAsync(page ?? 0, itemsOnPage,
                organizerFilterApplied, typesFilterApplied);
            }
            var vm = new EventIndexViewModel
            {
                Organizers = await _service.GetOrganizersAsync(),
                Types = await _service.GetCategoriesAsync(),
                Events = events.Data,
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = events.PageIndex,
                    TotalItems = events.Count,
                    ItemsPerPage = events.PageSize,
                    TotalPages = (int)Math.Ceiling((decimal)events.Count / itemsOnPage)
                },
                OrganizerFilterApplied = organizerFilterApplied,
                TypesFilterApplied = typesFilterApplied
            };

            return View(vm);
        }
        [Authorize]
        public IActionResult About()
        {
            return View();
        }
         
        
    }
}
