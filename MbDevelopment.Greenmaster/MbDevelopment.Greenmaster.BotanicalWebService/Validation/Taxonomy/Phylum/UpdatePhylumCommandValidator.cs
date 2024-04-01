using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Phylum;

public class UpdatePhylumCommandValidator : AbstractValidator<UpdateClassCommand>
{
    public UpdatePhylumCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.PhylumId).NotEmpty();
    }
}