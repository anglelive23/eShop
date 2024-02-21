namespace eShop.Application.Contracts
{
    public interface IItemRepository : IAsyncRepository<Item>
    {
        #region POST
        Task<Item> AddItemAsync(Item item);
        #endregion

        #region PUT
        Task<Item?> UpdateItemAsync(int id, Item item);
        #endregion

        #region DELETE
        Task<bool> RemoveItemAsync(int id);
        #endregion
    }
}
