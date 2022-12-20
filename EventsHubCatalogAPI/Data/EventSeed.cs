using EventsHubCatalogAPI.Domain;
using Microsoft.EntityFrameworkCore;

namespace EventsHubCatalogAPI.Data
{
    public static class EventSeed
    {
        public static void Seed(EventContext context)
        {
            context.Database.Migrate();

            if(!context.CategoryTypes.Any())
            {
                context.CategoryTypes.AddRange(GetCategoryTypes());
                context.SaveChanges();
            }
            if (!context.OrganizerTypes.Any())
            {
                context.OrganizerTypes.AddRange(GetOrganizerTypes());
                context.SaveChanges();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(GetEventTypes());
                context.SaveChanges();
            }
        }
        private static IEnumerable<OrganizerType> GetOrganizerTypes()
        {
            return new List<OrganizerType>
            {
                new OrganizerType{Organizer="VIP Fun"},
                new OrganizerType{Organizer="Shameless"},
                new OrganizerType{Organizer="Crazy Adventures"}
            };
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
        private static IEnumerable<EventType> GetEventTypes()
        {
            return new List<EventType>()
            {
                new EventType { CategoryTypeId = 4, OrganizerTypeId = 3, DateTime = Convert.ToDateTime("2022-12-15 12:00:00.000"), Description = "Celebrate the joy of the season with Seattle Girls Choir as they share A Gift of Song. Join us as we fill Town Hall with a lovely selection of holiday music sure to delight everyone!", Name = "A Gift of Song", Price = 20, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/1" },
                new EventType { CategoryTypeId = 6, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-08-26 08:00:00.000"), Description = "Join a host of local organizations to learn more about getting active outdoors at this family-friendly community event. ", Name = "Explore the Outdoors Family Fair", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/2" },
                new EventType { CategoryTypeId = 4, OrganizerTypeId = 3, DateTime = Convert.ToDateTime("2022-10-17 11:00:00.000"), Description = "UCU is Seattle's largest indie craft show, hosting over 150 independent designers, artists, crafters and makers at our biannual shows.", Name = "Handmade Gift Show", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/3" },
                new EventType { CategoryTypeId = 3, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-12-16 21:00:00.000"), Description = "Start your night off with a laugh! Come to a happy hour full of spontaneous fun! Comedy improv for all ages.", Name = "Improv Happy Hour", Price = 15, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/4" },
                new EventType { CategoryTypeId = 7, OrganizerTypeId = 1, DateTime = Convert.ToDateTime("2022-12-31 20:00:00.000"), Description = "New Years Eve is undoubtably the BIGGEST PARTY of the year and deciding where for you and your friends will ring in the new year is a tough decision.", Name = "New Years Eve Bar Crawl", Price = 14.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/5" },
                new EventType { CategoryTypeId = 7, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-12-13 10:00:00.000"), Description = "P﻿lease join us for our annual Holiday celebration. This year's brunch will highlight Black Excellence through our theme of Wakanda Wonderland.", Name = "Wakanda Wonderland", Price = 50, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/6" },
                new EventType { CategoryTypeId = 4, OrganizerTypeId = 1, DateTime = Convert.ToDateTime("2022-12-11 18:00:00.000"), Description = "Come enjoy God Awful Movies at Brodway Performance Hall. We'll be breaking down some of Christian cinema’s crummiest creations with all the hand waving, facial expressions, and costume changes you never knew you were missing.", Name = "God Awful Movies", Price = 200, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/7" },
                new EventType { CategoryTypeId = 5, OrganizerTypeId = 1, DateTime = Convert.ToDateTime("2022-09-21 09:00:00.000"), Description = "G﻿ive your child the BEST DAY EVER with all their favorite princesses! S﻿hare stories, songs, dances, games, and more with a high-quality cast of characters.", Name = "Bellevue Princess Day", Price = 25, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/8" },
                new EventType { CategoryTypeId = 5, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-11-24 17:00:00.000"), Description = "'﻿Tis the season for wellness. Join resident yoga instructor, Morgan Zion for a one-hour yoga class, followed by a tasty treat in TRACE Market.", Name = "Sleigh All Day Yoga", Price = 129, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/9" },
                new EventType { CategoryTypeId = 1, OrganizerTypeId = 3, DateTime = Convert.ToDateTime("2022-10-09 15:00:00.000"), Description = "Experience an in-depth look at the unique Seattle Roastery and learn about the Starbucks Reserve® Brand through a private tour. This tour takes you on a coffee journey from farm to cup and presents you with up-close views of the incredible roasting process.", Name = "Starbucks Experience Tour & Tasting", Price = 45, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/10" },
                new EventType { CategoryTypeId = 2, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-12-21 10:00:00.000"), Description = "A new series of dance productions created for children and their families. A one-hour spectacle of pure wonder, based on the classic tale The Wonderful Wizard of Oz.", Name = "The Wizard of Oz", Price = 27, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/11" },
                new EventType { CategoryTypeId = 3, OrganizerTypeId = 1, DateTime = Convert.ToDateTime("2022-12-23 19:00:00.000"), Description = "Meet us at the Royal Esquire for a much requested Game Night... Ugly Sweater edition!", Name = "Ugly Sweater Game Night", Price = 412, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/12" },
                new EventType { CategoryTypeId = 6, OrganizerTypeId = 3, DateTime = Convert.ToDateTime("2022-12-10 14:00:00.000"), Description = "We will show you how to make the JustFoodForDogs Beef & Russet Potato Recipe from ingredients easily found in your local grocery store!", Name = "Learn to Cook for your Dog", Price = 19.99M, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/13" },
                new EventType { CategoryTypeId = 2, OrganizerTypeId = 2, DateTime = Convert.ToDateTime("2022-11-19 18:00:00.000"), Description = "Come to discuss the current moon phase, set your intentions for the month, and enjoy some good conversation and a bit of self-care.", Name = "New Moon Tea Party", Price = 0, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/14" },
                new EventType { CategoryTypeId = 1, OrganizerTypeId = 1, DateTime = Convert.ToDateTime("2022-12-20 13:00:00.000"), Description = "This class will teach you how to purchase your first rental, fix & flip, hard money, financing options and credit preparation!", Name = "Building Wealth Through Real Estate", Price = 299, PictureUrl = "http://externalcatalogbaseurltobereplaced/api/pic/15" }
            };
        }
    }
}
