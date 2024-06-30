using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Genus;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Genus;

public class DeleteGenusCommandValidator : AbstractValidator<DeleteGenusCommand>
{
    public DeleteGenusCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}