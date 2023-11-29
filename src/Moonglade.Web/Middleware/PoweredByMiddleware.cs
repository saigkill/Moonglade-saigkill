namespace Moonglade.Web.Middleware;

public class PoweredByMiddleware(RequestDelegate next)
{
    public Task Invoke(HttpContext httpContext)
    {
        httpContext.Response.Headers["X-Powered-By"] = $"Moonglade-saigkill {Helper.AppVersion}";
        return _next.Invoke(httpContext);
    }
}
