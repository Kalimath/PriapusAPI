using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Family;

public class DeleteFamilyCommandValidator : AbstractValidator<DeleteClassCommand>
{
    public DeleteFamilyCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}