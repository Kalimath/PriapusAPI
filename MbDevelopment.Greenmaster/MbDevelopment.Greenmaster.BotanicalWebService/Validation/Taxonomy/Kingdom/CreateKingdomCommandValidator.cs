using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Kingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Kingdom;

public class CreateKingdomCommandValidator : AbstractValidator<CreateKingdomCommand>
{
    public CreateKingdomCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}