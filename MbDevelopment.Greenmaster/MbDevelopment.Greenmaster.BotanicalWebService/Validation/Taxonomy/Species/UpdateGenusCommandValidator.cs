using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Commands.Taxonomy.Species;
using MbDevelopment.Greenmaster.Core.Utils;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Species;

public class UpdateSpeciesCommandValidator : AbstractValidator<UpdateSpeciesCommand>
{
    public UpdateSpeciesCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.CommonName).NotEmpty();
        RuleFor(x => x.GenusId).NotEmpty();
        RuleFor(x => x.ImageUrl).Must(StringUtils.LinkMustBeAUri).WithMessage(x => $"{nameof(x.ImageUrl)} must be a valid link");
    }
}