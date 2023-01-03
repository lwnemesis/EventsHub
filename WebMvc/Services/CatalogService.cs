using Microsoft.AspNetCore.Mvc.Rendering;
using WebMvc.Infrastructure;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WebMvc.Models;

namespace WebMvc.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IHttpClient _httpClient;
        private readonly string _baseUrl;
        public CatalogService(IConfiguration config, IHttpClient client)
        {
            _httpClient = client;
            _baseUrl = $"{config["CatalogUrl"]}/api/event";
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var typesUri = APIPaths.Catalog.GetAllCategories(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(typesUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true,
                }
            };
            var categories = JArray.Parse(dataString);
            foreach (var item in categories)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("type")
                });
            }
            return items;
        }

        public async Task<EventsCatalog> GetEventsAsync(int page, int size, int? organizer, int? type)
        {
            var eventsUri = APIPaths.Catalog.GetAllEvents(_baseUrl, page, size, organizer, type);
            var dataString = await _httpClient.GetStringAsync(eventsUri);
            return JsonConvert.DeserializeObject<EventsCatalog>(dataString);
        }

        public async Task<IEnumerable<SelectListItem>> GetOrganizersAsync()
        {
            var organizerUri = APIPaths.Catalog.GetAllOrganizers(_baseUrl);
            var dataString = await _httpClient.GetStringAsync(organizerUri);
            var items = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true,
                }
            };
            var organizers = JArray.Parse(dataString);
            foreach (var item in organizers)
            {
                items.Add(new SelectListItem
                {
                    Value = item.Value<string>("id"),
                    Text = item.Value<string>("organizer")
                });
            }
            return items;
        }
    }
}
