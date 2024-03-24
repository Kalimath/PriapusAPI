using FluentValidation;
using MbDevelopment.Greenmaster.Contracts.WebApi.Taxonomy.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

public class DeleteKingdomCommand : IRequest<KingdomDto>
{
    public string Id { get; set; }
}

public class DeleteKingdomCommandValidator : AbstractValidator<DeleteKingdomCommand>
{
    public DeleteKingdomCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}