namespace eShop.Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(o => o.CreateSalesDto.CustomerId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.CreateSalesDto.CurrencyCode)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(o => o.CreateSalesDto.DiscountPromoCode)
                .MaximumLength(25).WithMessage("{PropertyName} Maxlength is 25!");

            RuleFor(s => s.CreateSalesDto.SalesLines)
                 .NotEmpty().WithMessage("{PropertyName} is required!")
                 .ForEach(line =>
                 {
                     line.SetValidator(new SalesLineValidator());
                 });
        }
    }

    public class SalesLineValidator : AbstractValidator<CreateSalesLineDto>
    {
        public SalesLineValidator()
        {
            RuleFor(l => l.ItemId)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.QTY)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
