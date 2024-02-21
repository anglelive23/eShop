namespace eShop.Application.Features.Items.Queries.GetItemDetails
{
    public class GetItemDetailsQueryValidator : AbstractValidator<GetItemDetailsQuery>
    {
        public GetItemDetailsQueryValidator()
        {
            RuleFor(i => i.Id)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
