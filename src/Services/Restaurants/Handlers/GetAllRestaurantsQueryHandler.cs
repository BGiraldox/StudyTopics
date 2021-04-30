using MediatR;
using Services.Mocks;
using Services.Models;
using Services.Restaurants.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Restaurants.Handlers
{
    public class GetAllRestaurantsQueryHandler : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<Restaurant>>
    {
        private readonly IReadRepo<Restaurant> _repo;

        public GetAllRestaurantsQueryHandler(IReadRepo<Restaurant> repository)
        {
            _repo = repository;
        }

        public Task<IEnumerable<Restaurant>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_repo.GetAll());
        }
    }
}