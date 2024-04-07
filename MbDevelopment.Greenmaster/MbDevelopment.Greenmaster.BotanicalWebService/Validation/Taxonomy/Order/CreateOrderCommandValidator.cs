using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Order;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ClassId).NotEmpty();
    }
}