using eShop.Application.Models.Dtos;

namespace eShop.Infrastructure.Services
{
    public class SalesOrdersService(ISalesRepository repo, eShopContext context, IPriceCalculator priceCalculator, IConfiguration configuration) : ISalesOrdersService
    {
        #region Interface Implementation
        public async Task<SalesHeader> AddSalesHeaderAsync(CreateSalesHeaderDto salesHeaderDto)
        {
            // calc total price
            var orderPrice = await priceCalculator
                .CalculateOrderPrice(salesHeaderDto);

            // form the object to be added to db
            var order = new SalesHeader
            {
                RequestDate = DateTime.UtcNow,
                CustomerId = salesHeaderDto.CustomerId,
                DiscountPromoCode = salesHeaderDto.DiscountPromoCode,
                DiscountValue = decimal.Parse(configuration.GetSection("PromoCode:VS02").Value!),
                Status = Status.Open,
                TotalPrice = orderPrice,
                // Map SalesLineDto to SalesLine
                SalesLines = salesHeaderDto.SalesLines.Select(line => new SalesLine
                {
                    ItemId = line.ItemId,
                    CurrencyCode = line.CurrencyCode,
                    QTY = line.QTY,
                    // price

                    // exchange rate
                }).ToList(),
            };

            // call db and save the object
            var checkAdd = await repo
                .AddSalesHeaderAsync(order);
            return checkAdd;
        }
        #endregion
    }
}
