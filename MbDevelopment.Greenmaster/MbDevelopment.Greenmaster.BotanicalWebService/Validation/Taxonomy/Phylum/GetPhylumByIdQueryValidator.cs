using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Phylum;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Phylum;

public class GetPhylumByIdQueryValidator : AbstractValidator<GetPhylumByIdQuery>
{
    public GetPhylumByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}