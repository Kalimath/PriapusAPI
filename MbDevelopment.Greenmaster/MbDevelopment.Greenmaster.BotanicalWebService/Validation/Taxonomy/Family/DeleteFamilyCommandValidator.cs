using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Family;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Family;

public class DeleteFamilyCommandValidator : AbstractValidator<DeleteFamilyCommand>
{
    public DeleteFamilyCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}