using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Class;

public class UpdateClassCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdateClassCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PhylumId).NotEmpty();
    }
}