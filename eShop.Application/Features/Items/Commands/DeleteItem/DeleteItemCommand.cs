namespace eShop.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<bool>
    {
        public int Key { get; set; }
    }
}
