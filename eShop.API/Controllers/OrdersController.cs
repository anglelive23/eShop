namespace eShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IMediator mediator) : ControllerBase
    {
        #region GET
        [HttpGet(nameof(GetAllOrders))]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await mediator
                .Send(new GetOrdersListQuery());
            return Ok(orders);
        }
        #endregion

        #region POST
        [HttpPost(nameof(AddOrder))]
        [Authorize(Roles = "Customer, Admin")]
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
        #endregion
    }
}
