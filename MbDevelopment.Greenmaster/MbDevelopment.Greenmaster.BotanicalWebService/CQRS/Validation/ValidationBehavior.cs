using FluentValidation;
using MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;
using MediatR;
using Microsoft.VisualBasic;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Validation;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse> where TResponse : ApiResponse, new()
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        //pre
        var context = new ValidationContext<TRequest>(request);
        var failures = _validators
            .Select(x => x.Validate(context))
            .SelectMany(x => x.Errors)
            .Where(x => x != null)
            .ToList();

        if (failures.Count != 0)
        {
            return new TResponse()
            {
                Ok = false,
                Error = string.Join(" | ", failures.Select(x => x.ErrorMessage))
            };
        }

        return await next();
        //TODO: post
    }
}