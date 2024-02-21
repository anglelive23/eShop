namespace eShop.Application.Contracts
{
    public interface ISalesRepository
    {
        #region POST
        Task<SalesHeader> AddSalesHeaderAsync(SalesHeader salesHeader);
        #endregion
    }
}
