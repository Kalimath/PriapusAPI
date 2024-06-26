using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Class;

public class GetClassByIdQueryValidator : AbstractValidator<GetClassByIdQuery>
{
    public GetClassByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}