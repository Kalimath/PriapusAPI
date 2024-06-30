using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Genus;

public class UpdateGenusCommandValidator : AbstractValidator<UpdateGenusCommand>
{
    public UpdateGenusCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.FamilyId).NotEmpty();
    }
}