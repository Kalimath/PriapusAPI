using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Genus;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Genus;

public class GetGenusByIdQueryValidator : AbstractValidator<GetGenusByIdQuery>
{
    public GetGenusByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}