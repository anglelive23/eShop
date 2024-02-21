using eShop.Application.Features.Items.Notifications;

namespace eShop.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler(IItemRepository repo, IMediator mediator) : IRequestHandler<DeleteItemCommand, bool>
    {
        public async Task<bool> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteItemCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkDelete = await repo
                .RemoveItemAsync(request.Key);

            if (checkDelete)
                await mediator.Publish(new ItemDeletedNotification { Key = "item" }, cancellationToken);
            return checkDelete;
        }
    }
}
