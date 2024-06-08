using System.Text;

namespace cube_practice.Middlewares;

public class RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
{

    public async Task InvokeAsync(HttpContext context)
    {
        var requestBody = await GetRequestBodyAsString(context);
        logger.LogInformation($"[Request] Path: {context.Request.Method} {context.Request.Path} Body: {requestBody}");


        await next(context);

    }

   
    private static async Task<string> GetRequestBodyAsString(HttpContext context)
    {
        try
        {
            context.Request.EnableBuffering();
            context.Request.Body.Position = 0;
            return await new StreamReader(context.Request.Body).ReadToEndAsync();
        }
        catch
        {
            return "";
        }
    }
}