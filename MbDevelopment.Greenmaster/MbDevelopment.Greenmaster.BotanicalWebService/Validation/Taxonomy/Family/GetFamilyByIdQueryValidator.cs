using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Family;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Family;

public class GetFamilyByIdQueryValidator : AbstractValidator<GetFamilyByIdQuery>
{
    public GetFamilyByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}