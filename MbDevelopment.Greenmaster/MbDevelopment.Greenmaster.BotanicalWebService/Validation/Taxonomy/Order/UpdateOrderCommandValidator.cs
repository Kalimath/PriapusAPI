using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Order;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}