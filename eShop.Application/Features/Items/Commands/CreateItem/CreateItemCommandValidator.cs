namespace eShop.Application.Features.Items.Commands.CreateItem
{
    public class CreateItemCommandValidator : AbstractValidator<CreateItemCommand>
    {
        public CreateItemCommandValidator()
        {
            RuleFor(i => i.ItemDto.Description)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(255).WithMessage("{PropertyName} max length is 255!");

            RuleFor(i => i.ItemDto.Name)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(100).WithMessage("{PropertyName} max length is 100!");

            RuleFor(i => i.ItemDto.QTY)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(i => i.ItemDto.Price)
               .NotEmpty().WithMessage("{PropertyName} is required!")
                .PrecisionScale(18, 2, true).WithMessage("{PropertyName} precision is 18 and scale is 2.");

            RuleFor(i => i.ItemDto.UOM)
                .NotEmpty().WithMessage("{PropertyName} is required!");

            RuleFor(i => i.ItemDto.UOM.UOM)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(10).WithMessage("{PropertyName} max length is 10");

            RuleFor(i => i.ItemDto.UOM.Description)
                .NotEmpty().WithMessage("{PropertyName} is required!")
                .MaximumLength(25).WithMessage("{PropertyName} max length is 25");
        }
    }
}
