using MediatR;
using Services.Models;
using System.Collections.Generic;

namespace Services.Restaurants.Queries
{
    public class GetAllRestaurantsQuery : IRequest<IEnumerable<Restaurant>> { }
}