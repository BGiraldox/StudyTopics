using Services.Models;

namespace Services.Mocks
{
    public class RestaurantWriteRepo : IWriteRepo<AddRestaurant>
    {
        public void Add(AddRestaurant entity)
        {
            RestaurantReadRepo.Restaurants.Add(new Restaurant
            {
                Name = entity.Name,
                Address = entity.Address,
                Code = entity.Code
            });
        }
    }
}