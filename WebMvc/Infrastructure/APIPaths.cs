namespace WebMvc.Infrastructure
{
    public static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllOrganizers(string baseUri)
            {
                return $"{baseUri}/organizertypes";
            }

            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}/categorytypes";
            }

            public static string GetAllEvents(string baseUri, int page, int take, int? organizer, int? category)
            {
                var preUri = string.Empty;
                var filterQs = string.Empty;

                if (organizer.HasValue)
                {
                    filterQs = $"OrganizerTypeId={organizer.Value}";
                }

                if (category.HasValue)
                {
                    filterQs = (filterQs == string.Empty) ? $"categoryTypeId={category.Value}" :
                         $"{filterQs}&categoryTypeId={category.Value}";
                }

                if (string.IsNullOrEmpty(filterQs))
                {
                    preUri = $"{baseUri}/events?pageIndex={page}&pageSize={take}";
                }

                else
                {
                    preUri = $"{baseUri}/events/filter?pageIndex={page}&pageSize={take}&{filterQs}";
                }

                return preUri;
            }
        }
    }
}
