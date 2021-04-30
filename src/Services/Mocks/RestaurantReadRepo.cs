using Services.Models;
using System.Collections.Generic;

namespace Services.Mocks
{
    public class RestaurantReadRepo : IReadRepo<Restaurant>
    {
        public static List<Restaurant> Restaurants = new List<Restaurant>
            {
                new Restaurant
                {
                    Name = "Frisby",
                    Address = "Calle #1",
                    Code = 1
                },
                new Restaurant
                {
                    Name = "Kokoriko",
                    Address = "Calle #2",
                    Code = 2
                },
                new Restaurant
                {
                    Name = "Burguer King",
                    Address = "Calle #3",
                    Code = 3
                }
            };

        public IEnumerable<Restaurant> GetAll()
        {
            return Restaurants;
        }
    }
}