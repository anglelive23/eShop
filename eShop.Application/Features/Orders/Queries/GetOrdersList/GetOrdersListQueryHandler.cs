namespace eShop.Application.Features.Orders.Queries.GetOrdersList
{
    public class GetOrdersListQueryHandler(ISalesRepository repo) : IRequestHandler<GetOrdersListQuery, List<SalesHeaderDto>>
    {
        public async Task<List<SalesHeaderDto>> Handle(GetOrdersListQuery request, CancellationToken cancellationToken)
        {
            var orders = await repo
                .GetAll(o => o.IsDeleted == false)
                .Include(o => o.SalesLines)!
                .ThenInclude(l => l.Item)
                .AsSplitQuery()
                .AsNoTracking()
                .ToListAsync();

            return orders.Adapt<List<SalesHeaderDto>>();
        }
    }
}
