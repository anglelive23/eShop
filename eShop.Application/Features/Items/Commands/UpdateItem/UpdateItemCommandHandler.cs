using eShop.Application.Features.Items.Notifications;
using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler(IItemRepository repo, IMediator mediator) : IRequestHandler<UpdateItemCommand, ItemDto?>
    {
        public async Task<ItemDto?> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateItemCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkUpdate = await repo
                .UpdateItemAsync(request.Key, request.ItemDto.Adapt<Item>());
            if (checkUpdate != null)
                await mediator.Publish(new ItemUpdatedNotification { Key = "item" }, cancellationToken);
            return checkUpdate.Adapt<ItemDto>();
        }
    }
}
