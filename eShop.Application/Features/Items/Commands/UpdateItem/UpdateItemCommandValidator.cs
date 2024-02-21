namespace eShop.Application.Features.Items.Commands.UpdateItem
{
    public class UpdateItemCommandValidator : AbstractValidator<UpdateItemCommand>
    {
        public UpdateItemCommandValidator()
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

            RuleFor(i => i.ItemDto.UOMId)
                .NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
