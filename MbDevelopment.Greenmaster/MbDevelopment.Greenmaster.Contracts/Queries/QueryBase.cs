using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries;

public class QueryBase<T> : IRequest<T> where T : class
{
}