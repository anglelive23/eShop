namespace eShop.Application.Features.Items.Commands.DeleteItem
{
    public class DeleteItemCommandValidator : AbstractValidator<DeleteItemCommand>
    {
        public DeleteItemCommandValidator()
        {
            RuleFor(i => i.Key)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
