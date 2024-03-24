using MediatR;

namespace MbDevelopment.Greenmaster.Contracts.Commands;

public class CommandBase<T> : IRequest<T> where T : class{}