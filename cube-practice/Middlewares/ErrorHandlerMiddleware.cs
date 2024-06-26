namespace cube_practice.Middlewares;

public class ErrorHandlerMiddleware(ILogger<ErrorHandlerMiddleware> logger, RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            logger.LogError(e.ToString());
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("something went wrong, pls contact support");
        }
    }

}