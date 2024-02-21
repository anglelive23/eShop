using AutoMapper;
using AutoMapper.AspNet.OData;
using eShop.Application.Models;
using eShop.Application.Models.Dtos;
using Microsoft.AspNetCore.Http;

namespace eShop.Application.Features.Items.Queries.GetItemDetails
{
    public class GetItemDetailsQueryHandler(ICacheService cache, IItemRepository repo, IHttpContextAccessor contextAccessor, IMapper mapper) : IRequestHandler<GetItemDetailsQuery, ItemDto?>
    {
        public async Task<ItemDto?> Handle(GetItemDetailsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetItemDetailsQueryValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var query = contextAccessor.HttpContext!.Request.QueryString.ToString();
            var key = string.IsNullOrEmpty(query)
                ? Constants.ItemKey
                : $"{Constants.ItemsKey}-{query}";
            var itemDto = await cache
                    .GetAsync(key, async () =>
                    {
                        var item = await repo
                            .GetAll(r => r.Id == request.Id && r.IsDeleted == false)
                            .GetQueryAsync(mapper, request.QueryOptions);

                        return item.FirstOrDefault()!;
                    }, CacheOptions.DefaultExpiration
                    , cancellationToken);
            return itemDto;
        }
    }
}
