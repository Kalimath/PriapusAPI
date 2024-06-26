using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Family;

public class UpdateFamilyCommandValidator : AbstractValidator<UpdateFamilyCommand>
{
    public UpdateFamilyCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.OrderId).NotEmpty();
    }
}