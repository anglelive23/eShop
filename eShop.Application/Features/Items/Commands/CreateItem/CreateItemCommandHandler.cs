using eShop.Application.Features.Items.Notifications;
using eShop.Application.Models;
using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandHandler(IItemRepository repo, IMediator mediator) : IRequestHandler<CreateItemCommand, ItemDto>
    {
        public async Task<ItemDto> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateItemCommandValidator();
            await validator.ValidateAndThrowAsync(request, cancellationToken);

            var checkAdd = await repo
                .AddItemAsync(request.ItemDto.Adapt<Item>());

            await mediator.Publish(new ItemCreatedNotification
            {
                Key = Constants.ItemsKey
            });

            return checkAdd.Adapt<ItemDto>();
        }
    }
}
