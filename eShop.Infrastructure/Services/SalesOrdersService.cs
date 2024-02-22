using eShop.Application.Models;
using eShop.Application.Models.Dtos;

namespace eShop.Infrastructure.Services
{
    public class SalesOrdersService(ISalesRepository repo, IItemRepository itemRepo, IPriceCalculator priceCalculator, IConfiguration configuration) : ISalesOrdersService
    {
        #region Interface Implementation
        public async Task<SalesHeader> AddSalesHeaderAsync(CreateSalesHeaderDto salesHeaderDto)
        {
            var (orderPrice, exchageRate) = await priceCalculator
                .CalculateOrderPrice(salesHeaderDto);

            var order = new SalesHeader
            {
                RequestDate = DateTime.UtcNow,
                CustomerId = salesHeaderDto.CustomerId,
                DiscountPromoCode = salesHeaderDto.DiscountPromoCode,
                DiscountValue = string.IsNullOrEmpty(salesHeaderDto.DiscountPromoCode) ? 0 : decimal.Parse(configuration.GetSection(Constants.PromoCode).Value!),
                Status = Status.Open,
                TotalPrice = orderPrice,
                CurrencyCode = salesHeaderDto.CurrencyCode,
                ExchangeRate = exchageRate,
                SalesLines = salesHeaderDto.SalesLines.Select(line => new SalesLine
                {
                    ItemId = line.ItemId,
                    QTY = line.QTY,
                    Price = GetItemPrice(line.ItemId) * line.QTY
                }).ToList(),
            };

            var checkAdd = await repo
                .AddSalesHeaderAsync(order);
            return checkAdd;
        }
        #endregion

        #region Helper Methods
        public decimal GetItemPrice(int itemId)
        {
            var item = itemRepo
                .GetAll(i => i.Id == itemId)
                .FirstOrDefault();
            return item!.Price;
        }
        #endregion
    }
}
