using eShop.Application.Models.Dtos;

namespace eShop.Infrastructure.Services
{
    public class PriceCalculator(eShopContext context, IConfiguration configuration) : IPriceCalculator
    {
        public async Task<decimal> CalculateOrderPrice(CreateSalesHeaderDto orderDto)
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

            var test = configuration.GetSection("PromoCode:VS02").Key;
            if (!string.IsNullOrEmpty(orderDto.DiscountPromoCode) && string.Equals(orderDto.DiscountPromoCode, configuration.GetSection("PromoCode:VS02").Key))
            {
                decimal.TryParse(configuration.GetSection("PromoCode:VS02").Value, out decimal copoun);
                price -= copoun;
                return price;
            }

            return price;
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
