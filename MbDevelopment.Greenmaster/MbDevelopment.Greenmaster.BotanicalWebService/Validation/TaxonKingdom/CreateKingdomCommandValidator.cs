using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.TaxonKingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.TaxonKingdom;

public class CreateKingdomCommandValidator : AbstractValidator<CreateKingdomCommand>
{
    public CreateKingdomCommandValidator()
    {
        RuleFor(x => x.LatinName).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}