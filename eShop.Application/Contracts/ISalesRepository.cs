namespace eShop.Application.Contracts
{
    public interface ISalesRepository : IAsyncRepository<SalesHeader>
    {
        #region POST
        Task<SalesHeader> AddSalesHeaderAsync(SalesHeader salesHeader);
        #endregion
    }
}
