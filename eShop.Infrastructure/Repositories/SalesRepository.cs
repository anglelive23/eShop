namespace eShop.Infrastructure.Repositories
{
    public class SalesRepository : BaseRepository<SalesHeader>, ISalesRepository
    {
        #region Constructors
        public SalesRepository(eShopContext context) : base(context) { }
        #endregion

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
