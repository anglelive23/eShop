using eShop.Application.Models.Dtos;

namespace eShop.Application.Features.Currencies.Command.CacheCurrencies
{
    public class CacheCurrenciesCommandValidator : AbstractValidator<CacheCurrenciesCommand>
    {
        public CacheCurrenciesCommandValidator()
        {
            RuleFor(c => c.CurrenciesExchangeDto.CurrencyDtos)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .ForEach(currency =>
                {
                    currency.SetValidator(new CurrencyExchangeValidator());
                });
        }
    }

    public class CurrencyExchangeValidator : AbstractValidator<CurrencyDto>
    {
        public CurrencyExchangeValidator()
        {
            RuleFor(c => c.Value)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(l => l.Key)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
