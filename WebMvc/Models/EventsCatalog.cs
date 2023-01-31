namespace WebMvc.Models
{
    public class EventsCatalog
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventType> Data { get; set; }
    }
}
