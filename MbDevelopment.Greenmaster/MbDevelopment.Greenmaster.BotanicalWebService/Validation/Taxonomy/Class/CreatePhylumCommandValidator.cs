using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Class;

public class CreateClassCommandValidator : AbstractValidator<CreateClassCommand>
{
    public CreateClassCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PhylumId).NotEmpty();
    }
}