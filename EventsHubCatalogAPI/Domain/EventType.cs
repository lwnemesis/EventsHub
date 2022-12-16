namespace EventsHubCatalogAPI.Domain
{
    public class EventType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime DateTime { get; set; }
        public string PictureUrl { get; set; }
        public int CategoryTypeId { get; set; }
        public int OrganizerTypeId { get; set; }
        public virtual CategoryType CategoryType { get; set; }
        public virtual OrganizerType OrganizerType { get; set; }
    }
}
