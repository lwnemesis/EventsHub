using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Models;

namespace WebMvc.Services
{
    public interface ICatalogService
    {
        Task<EventCatalog> GetEventsAsync(int page, int size, int? organizer, int? type);
        Task<IEnumerable<SelectListItem>> GetOrganizersAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
