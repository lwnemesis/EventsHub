namespace WebMvc.infrastructure
{
    public  static class APIPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUrl)
            {
                return $"{baseUrl}/catalogtypes";
            }
            public static string GetAllOrganizers(string baseUrl)
            {
                return $"{baseUrl}/organizertypes";
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
