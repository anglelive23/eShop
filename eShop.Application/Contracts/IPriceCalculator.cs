namespace eShop.Application.Contracts
{
    public interface IPriceCalculator
    {
        Task<(decimal, int)> CalculateOrderPrice(CreateSalesHeaderDto orderDto);
    }
}
