using MediatR;
using Microsoft.AspNetCore.Mvc;
using Services.Models;
using Services.Restaurants.Commands;
using Services.Restaurants.Queries;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public string Get()
        {
            return "Hi";
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllRestaurants()
        {
            var response = await _mediator.Send(new GetAllRestaurantsQuery());
            return Ok(response);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> AddRestaurant([FromBody] AddRestaurantCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}