using eShop.Application.Models.Dtos;
using Microsoft.AspNetCore.OData.Query;

namespace eShop.Application.Features.Items.Queries.GetItemDetails
{
    public class GetItemDetailsQuery : IRequest<ItemDto?>
    {
        public int Id { get; set; }
        public ODataQueryOptions<ItemDto> QueryOptions { get; set; }
    }
}
