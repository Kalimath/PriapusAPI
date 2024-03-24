using MediatR;

namespace MbDevelopment.Greenmaster.BotanicalWebService.CQRS.Commands;

public class CommandBase<T> : IRequest<T> where T : class{}