namespace eShop.Application.Features.Currencies.Queries.GetCurrencyExchangeDetails
{
    public class GetCurrencyExchangeDetailsQueryValidator : AbstractValidator<GetCurrencyExchangeDetailsQuery>
    {
        public GetCurrencyExchangeDetailsQueryValidator()
        {
            RuleFor(c => c.Key)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
