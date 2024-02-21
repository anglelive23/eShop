using eShop.Application.Exceptions;
using Microsoft.Data.SqlClient;

namespace eShop.Infrastructure.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        #region Construcotors
        public ItemRepository(eShopContext context) : base(context) { }
        #endregion

        #region POST
        public async Task<Item> AddItemAsync(Item item)
        {
            try
            {
                _context.Items.Add(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region PUT
        public async Task<Item?> UpdateItemAsync(int id, Item item)
        {
            try
            {
                var currentItem = await GetByIdAsync(id);

                if (currentItem == null)
                    return null;

                currentItem.Name = item.Name;
                currentItem.Description = item.Description;
                currentItem.QTY = item.QTY;
                currentItem.Price = item.Price;
                currentItem.UOMId = item.UOMId;

                _context.Update(currentItem);
                await _context.SaveChangesAsync();

                return currentItem;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion

        #region DELETE
        public async Task<bool> RemoveItemAsync(int id)
        {
            try
            {
                var item = await GetByIdAsync(id);

                if (item == null)
                    return false;

                if (item.IsDeleted == true)
                    return true;

                item.IsDeleted = true;
                item.LastModifiedDate = DateTime.UtcNow;
                _context.Update(item);

                return _context.SaveChanges() > 0;
            }
            catch (Exception ex) when (ex is ArgumentNullException
                                    || ex is InvalidOperationException
                                    || ex is DbUpdateException
                                    || ex is SqlException)
            {
                throw new DataFailureException(ex.Message);
            }
        }
        #endregion
    }
}
