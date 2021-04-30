using MediatR;
using Services.Models;

namespace Services.Restaurants.Commands
{
    public class AddRestaurantCommand : IRequest<string>
    {
        public AddRestaurant Restaurant { get; set; }
    }
}