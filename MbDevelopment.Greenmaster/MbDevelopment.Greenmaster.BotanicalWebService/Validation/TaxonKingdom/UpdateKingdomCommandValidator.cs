using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.TaxonKingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.TaxonKingdom;

public class UpdateKingdomCommandValidator : AbstractValidator<UpdateKingdomCommand>
{
    public UpdateKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}