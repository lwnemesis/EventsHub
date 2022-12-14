using EventsHubCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsHubCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();

            if(!context.EventTypes.Any())
            {
                context.CategoryTypes.AddRange(GetCategoryTypes);
                context.SaveChanges();
            }
        }

        private static IEnumerable<CategoryType> GetCategoryTypes()
        {
            return new List<CategoryType>
            {
                new CategoryType{Type="Music"},
                new CategoryType{Type="Hobbies"},
                new CategoryType{Type="Business"},
                new CategoryType{Type="Health & Fitness"},
                new CategoryType{Type="Food & Drink"},
                new CategoryType{Type="Sports"},
                new CategoryType{Type="Holiday"}
            };
        }
    }
}
