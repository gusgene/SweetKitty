using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using UseCases.Order.Commands.CreateOrder;
using UseCases.Order.Dto;
using UseCases.Order.Queries.GetById;
namespace WepApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<OrdersController> _logger;

        public OrdersController(ISender sender, ILogger<OrdersController> logger)
        {
            _sender = sender;
            _logger = logger;
        }
        
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            var result = await _sender.Send(new GetOrderByIdQuery {Id = id});
            return result;
        }

        [HttpPost]
        public async Task<int> Create([FromBody]CreateOrderDto dto)
        {
            var id = await _sender.Send(new CreateOrderCommand {Dto = dto});
            return id;
        }
    }
}
