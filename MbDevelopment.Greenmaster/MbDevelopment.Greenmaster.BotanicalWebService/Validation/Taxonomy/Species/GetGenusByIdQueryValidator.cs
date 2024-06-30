using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Species;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Species;

public class GetSpeciesByIdQueryValidator : AbstractValidator<GetSpeciesByIdQuery>
{
    public GetSpeciesByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}