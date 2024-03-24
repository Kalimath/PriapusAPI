using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Kingdom;

public class UpdateKingdomCommandValidator : AbstractValidator<UpdateKingdomCommand>
{
    public UpdateKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}