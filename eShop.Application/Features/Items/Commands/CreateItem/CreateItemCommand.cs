using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommand : IRequest<ItemDto>
    {
        public CreateItemDto ItemDto { get; set; }
    }
}
