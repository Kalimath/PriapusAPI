using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

public class UpdateKingdomCommand : CommandBase<KingdomDto>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}

public class UpdateKingdomCommandValidator : AbstractValidator<UpdateKingdomCommand>
{
    public UpdateKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}