using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Family;

public class CreateFamilyCommandValidator : AbstractValidator<CreateFamilyCommand>
{
    public CreateFamilyCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.OrderId).NotEmpty();
    }
}