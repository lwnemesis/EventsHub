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

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }

        public static class Order
        {
            public static string GetOrder(string baseUri, string orderId)
            {
                return $"{baseUri}/{orderId}";
            }

            public static string AddNewOrder(string baseUri)
            {
                return $"{baseUri}/new";
            }
        }
    }
}
