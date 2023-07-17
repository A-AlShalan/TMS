using Newtonsoft.Json;
using TMS;
using TMS.Helpers;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _logger = logger;
        _next = next;
    }
    // Async => return Task Not Void
    public async Task InvokeAsync(HttpContext httpContext, AppDBContext appDBContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            Loggings loggings = new Loggings();
            switch (ex)
            {
                case NotFoundBusinessException exception:
                    _logger.Log(LogLevel.Debug, exception, "NotFoundBusinessException");
                    await HandleExceptionAsync(httpContext, StatusCodes.Status404NotFound, "TMS-NotFound",
                        exception.Message);
                    loggings.Type = 1;
                    loggings.Message = "NotFoundBusinessException";
                    break;
                case GenericBusinessException exception:
                    _logger.Log(LogLevel.Debug, exception, "GenericBusinessException");
                    await HandleExceptionAsync(httpContext, StatusCodes.Status400BadRequest, "TMS-GenericBussinessValidation",
                        exception.Message);
                    loggings.Type = 2;
                    loggings.Message = "GenericBusinessException";
                    break;

                case ConflictBusinessException exception:
                    _logger.Log(LogLevel.Debug, exception, "ConflictBusinessException");
                    await HandleExceptionAsync(httpContext, StatusCodes.Status400BadRequest, "Error", exception.Message);
                    loggings.Type = 3;
                    loggings.Message = "ConflictBusinessException";
                    break;

                    case { } exception:
                    Console.WriteLine(exception);
                    await HandleExceptionAsync(httpContext, StatusCodes.Status500InternalServerError,
                        "TMS-InternalServiceError", exception.Message);
                    loggings.Type = 4;
                    loggings.Message = "InternalServiceError";
                    break;
            }
            await appDBContext.Loggings.AddAsync(loggings);
            await appDBContext.SaveChangesAsync();
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, int statusCode, string error, string message)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;
        var result = JsonConvert.SerializeObject(new
        {
            title = error,
            status = statusCode,
            detail = message,
            traceId = Guid.NewGuid().ToString()
        });
        await context.Response.WriteAsync(result);
    }
}