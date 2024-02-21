using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<SalesHeaderDto?>
    {
        public CreateSalesHeaderDto CreateSalesDto { get; set; }
    }
}
