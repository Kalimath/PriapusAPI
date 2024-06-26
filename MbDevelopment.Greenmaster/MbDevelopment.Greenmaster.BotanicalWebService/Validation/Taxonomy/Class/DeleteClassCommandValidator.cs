using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Class;

public class DeleteClassCommandValidator : AbstractValidator<DeleteClassCommand>
{
    public DeleteClassCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}