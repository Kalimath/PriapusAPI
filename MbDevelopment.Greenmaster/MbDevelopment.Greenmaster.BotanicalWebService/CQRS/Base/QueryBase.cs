using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Queries;

public class QueryBase<T> : IRequest<T> where T : class
{
}