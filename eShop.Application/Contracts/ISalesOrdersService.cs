using eShop.Application.Models.Dtos;

namespace eShop.Application.Contracts
{
    public interface ISalesOrdersService
    {
        Task<SalesHeader> AddSalesHeaderAsync(CreateSalesHeaderDto salesHeaderDto);
    }
}
