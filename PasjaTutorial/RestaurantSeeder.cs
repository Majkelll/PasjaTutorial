using PasjaTutorial.Entities;
using System.Linq;
using System.Collections.Generic;
namespace PasjaTutorial
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
            new Restaurant()
            {
                Name = "KFC",
                Category = "Fast Food",
                Description = "Lorem ipsum description",
                ContactEmail = "contact@kfc.com",
                HasDelivery = true,
                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        Name = "Lorem ipsum Dish name",
                        Price = 10.30M,
                    },
                    new Dish()
                    {
                        Name = "Chicken Nuggets",
                        Price = 5.30M,
                    },
                },
                Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-001",
                    }
                },
            new Restaurant()
            {
                Name = "KFC2",
                Category = "Fast Food2",
                Description = "Lorem ipsum description2",
                ContactEmail = "contact@kfc.com2",
                HasDelivery = true,
                Dishes = new List<Dish>
                {
                    new Dish()
                    {
                        Name = "Lorem ipsum Dish name",
                        Price = 10.30M,
                    },
                    new Dish()
                    {
                        Name = "Chicken Nuggets",
                        Price = 5.30M,
                    },
                },
                Address = new Address()
                    {
                        City = "Krakow",
                        Street = "Dluga 5",
                        PostalCode = "30-001",
                    }
                }
            };
            return restaurants;
        }
    }
}
