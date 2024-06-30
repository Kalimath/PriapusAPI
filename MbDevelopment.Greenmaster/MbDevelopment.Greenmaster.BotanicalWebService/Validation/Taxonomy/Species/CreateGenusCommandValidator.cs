using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using static MbDevelopment.Greenmaster.Core.Utils.StringUtils;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Species;

public class CreateSpeciesCommandValidator : AbstractValidator<CreateSpeciesCommand>
{
    public CreateSpeciesCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.GenusId).NotEmpty();
        RuleFor(x => x.CommonName).NotEmpty();
        RuleFor(x => x.ImageUrl).Must(LinkMustBeAUri).WithMessage(x => $"{nameof(x.ImageUrl)} must be a valid link");
    }
}