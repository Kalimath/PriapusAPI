using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Order;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Validation.Taxonomy.Order;

public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
{
    public GetOrderByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}