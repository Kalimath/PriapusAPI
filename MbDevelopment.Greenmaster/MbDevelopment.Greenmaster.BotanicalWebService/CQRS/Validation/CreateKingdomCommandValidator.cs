using FluentValidation;
using MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Validation;

public class CreateKingdomCommandValidator : AbstractValidator<CreateKingdomCommand>
{
    public CreateKingdomCommandValidator()
    {
        RuleFor(x => x.LatinName).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}