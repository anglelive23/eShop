using eShop.Application.Models.Dtos;
using Microsoft.AspNetCore.OData.Query;

namespace eShop.Application.Features.Items.Queries.GetItemsList
{
    public class GetItemsListQuery : IRequest<List<ItemDto>>
    {
        public ODataQueryOptions<ItemDto> QueryOptions { get; set; }
    }
}
