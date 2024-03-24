using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.TaxonKingdom;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.TaxonKingdom;

public class GetKingdomByIdQueryValidator : AbstractValidator<GetKingdomByIdQuery>
{
    public GetKingdomByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}