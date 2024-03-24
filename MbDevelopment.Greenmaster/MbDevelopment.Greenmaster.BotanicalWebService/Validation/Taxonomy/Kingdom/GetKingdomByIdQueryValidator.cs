using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Kingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Kingdom;

public class GetKingdomByIdQueryValidator : AbstractValidator<GetKingdomByIdQuery>
{
    public GetKingdomByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}