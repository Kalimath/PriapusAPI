using FluentValidation;
using HashidsNet;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Phylum;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Phylum;

public class UpdatePhylumCommandValidator : AbstractValidator<UpdatePhylumCommand>
{
    public UpdatePhylumCommandValidator()
    {
        var hashids = new Hashids();
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.KingdomId).NotEmpty();
        RuleFor(x => x.KingdomId).NotEmpty();
    }
}