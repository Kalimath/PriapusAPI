using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Species;

public class DeleteSpeciesCommandValidator : AbstractValidator<DeleteGenusCommand>
{
    public DeleteSpeciesCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}