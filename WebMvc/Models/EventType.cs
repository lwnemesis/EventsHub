
namespace WebMvc.Models
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
        public string CategoryType { get; set; }
        public string OrganizerType { get; set; }
    }
}
