namespace eShop.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, SalesHeaderDto?>
    {
        #region Fields and Properties
        private readonly ISalesOrdersService _salesService;
        #endregion

        #region Constructors
        public CreateOrderCommandHandler(ISalesOrdersService salesService)
        {
            _salesService = salesService ?? throw new ArgumentNullException(nameof(salesService));
        }
        #endregion

        #region Interface Implementation
        public async Task<SalesHeaderDto?> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _salesService
                .AddSalesHeaderAsync(request.CreateSalesDto);

            if (order is null)
                return null;

            return order.Adapt<SalesHeaderDto>();
        }
        #endregion
    }
}
