using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Genus;

public class CreateGenusCommandValidator : AbstractValidator<CreateGenusCommand>
{
    public CreateGenusCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.FamilyId).NotEmpty();
    }
}