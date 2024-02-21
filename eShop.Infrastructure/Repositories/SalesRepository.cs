using eShop.Application.Exceptions;
using Microsoft.Data.SqlClient;

namespace eShop.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<SalesHeader>, ISalesRepository
    {
        public SalesRepository(eShopContext context) : base(context) { }

        #region POST
        public async Task<SalesHeader> AddSalesHeaderAsync(SalesHeader salesHeader)
        {
            try
            {
                _context.SalesHeaders.Add(salesHeader);
                await _context.SaveChangesAsync();

                return salesHeader;
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
