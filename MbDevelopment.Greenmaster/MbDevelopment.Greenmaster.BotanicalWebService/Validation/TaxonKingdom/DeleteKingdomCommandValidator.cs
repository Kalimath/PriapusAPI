using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.TaxonKingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.TaxonKingdom;

public class DeleteKingdomCommandValidator : AbstractValidator<DeleteKingdomCommand>
{
    public DeleteKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}