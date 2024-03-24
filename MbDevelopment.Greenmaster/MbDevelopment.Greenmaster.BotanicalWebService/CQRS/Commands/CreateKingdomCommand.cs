using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

public class CreateKingdomCommand : CommandBase<KingdomDto>
{
    public string LatinName { get; set; }
    public string Description { get; set; }
}

public class CreateKingdomCommandValidator : AbstractValidator<CreateKingdomCommand>
{
    public CreateKingdomCommandValidator()
    {
        RuleFor(x => x.LatinName).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}