using eShop.Application.Models;
using eShop.Application.Models.Dtos;

namespace eShop.Infrastructure.Services
{
    public class PriceCalculator(eShopContext context, IConfiguration configuration, ICacheService cache) : IPriceCalculator
    {
        public async Task<(decimal, int)> CalculateOrderPrice(CreateSalesHeaderDto orderDto)
        {
            decimal price = 0;
            // this dict contain item id as key, quantity as value
            Dictionary<int, int> itemQty = orderDto.SalesLines
                .ToDictionary(item => item.ItemId, item => item.QTY);
            // calc the price of each item(price * quantity) and add result to price
            await foreach (var itemPrice in GetItemPrices(itemQty))
            {
                price += itemPrice;
            }

            // compare price against entered CurrencyCode
            (price, int exchageRate) = await GetPriceForGivenCurrency(orderDto.CurrencyCode, price);

            // checks promo code
            var promoCodeSection = configuration.GetSection(Constants.PromoCode);
            if (!string.IsNullOrEmpty(orderDto.DiscountPromoCode) && string.Equals(orderDto.DiscountPromoCode, promoCodeSection.Key))
            {
                decimal.TryParse(promoCodeSection.Value, out decimal copoun);
                price -= copoun;
                return (price, exchageRate);
            }

            return (price, exchageRate);
        }
        public async Task<(decimal, int)> GetPriceForGivenCurrency(string orderCurrencyCode, decimal orderPrice)
        {
            // CASE: order currency = main currency
            var mainCurrency = configuration.GetSection(Constants.DefaultCurrency).Value;
            if (string.Equals(mainCurrency, orderCurrencyCode, StringComparison.OrdinalIgnoreCase))
                return (orderPrice, 1);

            // Get the rate of the given currency
            var currencies = await cache
                .GetAsync<CreateCurrenciesExchangeDto>(Constants.CurrenciesKey);
            var currency = currencies.CurrencyDtos
                .FirstOrDefault(c => c.Key == orderCurrencyCode);
            if (currency is null)
                throw new ApplicationException($"Currency with code {orderCurrencyCode} not found on cache server!");

            return (orderPrice / currency.Value, currency.Value);
        }
        public async IAsyncEnumerable<decimal> GetItemPrices(Dictionary<int, int> itemsDect)
        {
            foreach (var itemId in itemsDect.Keys)
            {
                var quantity = itemsDect[itemId];
                var item = await context.Items
                    .FirstOrDefaultAsync(i => i.Id == itemId);
                if (item is not null)
                    yield return item.Price * quantity;
            }
        }
    }
}
