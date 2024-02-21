namespace eShop.Application.Features.Items.Notifications
{
    public class CacheInvalidationTweetHandler(ICacheService cache) : INotificationHandler<ItemCreatedNotification>
        , INotificationHandler<ItemUpdatedNotification>
        , INotificationHandler<ItemDeletedNotification>
    {
        public Task Handle(ItemCreatedNotification notification, CancellationToken cancellationToken)
        {
            return HandleInternal(notification.Key);
        }

        public Task Handle(ItemUpdatedNotification notification, CancellationToken cancellationToken)
        {
            return HandleInternal(notification.Key);
        }

        public Task Handle(ItemDeletedNotification notification, CancellationToken cancellationToken)
        {
            return HandleInternal(notification.Key);
        }

        private async Task HandleInternal(string prefix)
        {
            await cache.RemoveByPrefixAsync(prefix);
        }
    }
}
