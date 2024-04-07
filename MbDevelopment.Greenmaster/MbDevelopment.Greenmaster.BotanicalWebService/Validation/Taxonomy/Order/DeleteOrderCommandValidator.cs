using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Order;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Order;

public class DeleteOrderCommandValidator : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}