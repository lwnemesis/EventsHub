using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.ViewModels
{
    public class EventIndexViewModel
    {
        public IEnumerable<SelectListItem> Organizers { get; set; }
        public IEnumerable<SelectListItem> Types { get; set; }
        public IEnumerable<EventType> Events { get; set; }
        public PaginationInfo PaginationInfo { get; set; }
        public int? OrganizerFilterApplied { get; set; }
        public int? TypesFilterApplied { get; set; }
    }
}
