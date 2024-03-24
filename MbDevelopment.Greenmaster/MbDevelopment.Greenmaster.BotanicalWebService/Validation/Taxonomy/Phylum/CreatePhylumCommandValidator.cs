using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Phylum;

public class CreatePhylumCommandValidator : AbstractValidator<CreatePhylumCommand>
{
    public CreatePhylumCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.KingdomId).NotEmpty();
    }
}