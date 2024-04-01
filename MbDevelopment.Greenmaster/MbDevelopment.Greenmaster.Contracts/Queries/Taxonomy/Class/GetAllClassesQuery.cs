using MbDevelopment.Greenmaster.Contracts.Dtos;
using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Queries.Taxonomy.Class;

public class GetAllClassesQuery : IRequest<IEnumerable<ClassDto>>
{
}