using AutoMapper;
using AutoMapper.AspNet.OData;
using eShop.Application.Models;
using eShop.Application.Models.Dtos;
using Microsoft.AspNetCore.Http;

namespace eShop.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQueryHandler(IItemRepository repo, ICacheService cache, IMapper mapper, IHttpContextAccessor contextAccessor) : IRequestHandler<GetItemsListQuery, List<ItemDto>>
    {
        public async Task<List<ItemDto>> Handle(GetItemsListQuery request, CancellationToken cancellationToken)
        {
            var query = contextAccessor.HttpContext!.Request.QueryString.ToString();
            var key = string.IsNullOrEmpty(query)
                ? Constants.ItemsKey
                : $"{Constants.ItemsKey}-{query}";

            var itemsDto = await cache.GetAsync(key, async () =>
            {
                var items = await repo
                        .GetAll(t => t.IsDeleted == false)
                        .GetQueryAsync(mapper, request.QueryOptions);
                return items.ToList();
            }, CacheOptions.DefaultExpiration
            , cancellationToken);

            return itemsDto;
        }
    }
}
