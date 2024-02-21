using eShop.Application.Models.Dtos;

namespace eShop.Application.Contracts
{
    public interface IPriceCalculator
    {
        Task<decimal> CalculateOrderPrice(CreateSalesHeaderDto orderDto);
    }
}
