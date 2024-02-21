using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommand : IRequest<ItemDto?>
    {
        public int Key { get; set; }
        public UpdateItemDto ItemDto { get; set; }
    }
}
