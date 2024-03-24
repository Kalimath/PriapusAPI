using System.Net;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MbDevelopment.Greenmaster.BotanicalWebService.Controllers.Taxonomy;

[ApiController]
[Route("api/v1/[controller]")]
//[ApiVersion("1.0")]
[Produces("application/json")]
public class ApiControllerBase : ControllerBase
{
    //public new User User => (User)HttpContext.Items["User"];
    private HttpStatusCode _statusCode = HttpStatusCode.OK;
    private readonly IMediator _mediator;
    public ApiControllerBase(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException();
    }

    #region Execute requests
    protected Task<IActionResult> ExecutePost<T>(IRequest<T> request, HttpStatusCode codeOnSuccess = HttpStatusCode.OK)
    {
        _statusCode = codeOnSuccess;
        return ExecuteAsync(request);
    }
    protected Task<IActionResult> ExecutePut<T>(IRequest<T> request)
    {
        _statusCode = HttpStatusCode.OK;
        return ExecuteAsync(request);
    }
    protected Task<IActionResult> ExecuteDelete<T>(IRequest<T> request)
    {
        _statusCode = HttpStatusCode.OK;
        return ExecuteAsync(request);
    }
    #endregion

    protected async Task<IActionResult> ExecuteAsync<T>(IRequest<T> request)
    {
        Response<T> response;
        try
        {
            if (request == null) throw new NullReferenceException("The received request cannot be null");
             var result = await _mediator.Send(request);
            response = new Response<T>(_statusCode, result, _statusCode.ToString());
            return StatusCode((int)_statusCode, response);
        }
        catch (NullReferenceException nex)
        {
            _statusCode = HttpStatusCode.BadRequest;
            response = new Response<T>(_statusCode, "null reference", new [] { nex.Message });
        }
        catch (ValidationException vex)
        {
            _statusCode = HttpStatusCode.BadRequest;
            response = new Response<T>(_statusCode, vex.Message, vex.Errors.Select(failure => failure.ErrorMessage).ToArray());
        }
        catch (Exception ex)
        {
            _statusCode = HttpStatusCode.InternalServerError;
            response = new Response<T>(_statusCode, "Internal server error", new [] { ex.Message });
        }

        return StatusCode((int)_statusCode, response);
    }
}

public class Response<T> : IResponse<T>
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
    public T Data { get; set; }


    public Response() { }
    public Response(T data)  { }
    public Response(HttpStatusCode statusCode, T data) : this(statusCode, default, default, data) { }
    public Response(HttpStatusCode statusCode, T data, string message): this(statusCode, message, default, data) { }
    public Response(HttpStatusCode statusCode, string message, string[] errors) : this(statusCode, message, errors, default) { }
    public Response(HttpStatusCode statusCode, string errormessage) : this(statusCode, errormessage, default,default) { }

    public Response(HttpStatusCode status, string message, string[] errors, T data)
    {
        Status = status;
        Message = message;
        Errors = errors;
        Data = data;
    }
}

public interface IResponse<T>
{
    public HttpStatusCode Status { get; set; }
    public string Message { get; set; }
    public string[] Errors { get; set; }
    public T Data { get; set; }
}