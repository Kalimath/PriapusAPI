using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;

public class GetKingdomByIdQuery(string id) : QueryBase<KingdomDto>
{
    public string Id { get; set; } = id;
}

public class GetKingdomByIdQueryValidator : AbstractValidator<GetKingdomByIdQuery>
{
    public GetKingdomByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}