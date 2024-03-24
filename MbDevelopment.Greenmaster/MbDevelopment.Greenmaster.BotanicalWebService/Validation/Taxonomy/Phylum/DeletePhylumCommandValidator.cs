using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Phylum;

public class DeletePhylumCommandValidator : AbstractValidator<DeletePhylumCommand>
{
    public DeletePhylumCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}