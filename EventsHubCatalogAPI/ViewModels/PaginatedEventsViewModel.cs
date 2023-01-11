using EventsHubCatalogAPI.Domain;

namespace EventsHubCatalogAPI.ViewModels
{
    public class PaginatedEventsViewModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventType> Data { get; set; }
    }
}
