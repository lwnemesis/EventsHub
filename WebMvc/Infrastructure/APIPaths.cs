namespace WebMvc.Infrastructure
{
    public class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}/categorytypes";
            }
            public static string GetAllOrganizers(string baseUri)
            {
                return $"{baseUri}/organizertypes";
            }
            public static string GetAllEvents(string baseUri, int page, int take, int? organizer, int? type)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;
                if (organizer.HasValue)
                {
                    filterQs = $"OrganizerTypeId={organizer.Value}";
                }
                if (type.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"categoryTypeId={type.Value}" :
                         $"{filterQs}&categoryTypeId={type.Value}";
                }
                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/items?pageIndex={page}&pageSize={take}";
                }
                else
                {
                    preUri = $"{baseUri}/items/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }
                return preUri;
            }

        }
    }
}
