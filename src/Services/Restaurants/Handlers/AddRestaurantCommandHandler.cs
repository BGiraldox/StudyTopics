using MediatR;
using Services.Mocks;
using Services.Models;
using Services.Restaurants.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace Services.Restaurants.Handlers
{
    public class AddRestaurantCommandHandler : IRequestHandler<AddRestaurantCommand, string>
    {
        private readonly IWriteRepo<AddRestaurant> _repo;

        public AddRestaurantCommandHandler(IWriteRepo<AddRestaurant> repository)
        {
            _repo = repository;
        }

        public Task<string> Handle(AddRestaurantCommand request, CancellationToken cancellationToken)
        {
            _repo.Add(request.Restaurant);
            return Task.FromResult("Succeded");
        }
    }
}