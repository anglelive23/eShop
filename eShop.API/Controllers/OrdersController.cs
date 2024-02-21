using eShop.Application.Features.Orders.Commands.CreateOrder;
using eShop.Application.Models.Dtos;

namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> AddOrder(CreateSalesHeaderDto salesHeaderDto)
        {
            var order = await mediator
                .Send(new CreateOrderCommand
                {
                    CreateSalesDto = salesHeaderDto,
                });

            if (order == null)
                return BadRequest("something went wrong!");

            return Ok(order);
        }
    }
}
