using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Kingdom;

public class DeleteKingdomCommandValidator : AbstractValidator<DeleteKingdomCommand>
{
    public DeleteKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}