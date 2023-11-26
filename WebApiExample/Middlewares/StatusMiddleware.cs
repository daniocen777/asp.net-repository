namespace WebApiExample.Middlewares
{
    public class StatusMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public StatusMiddleware(RequestDelegate request)
        {
               _requestDelegate = request;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _requestDelegate(httpContext);
            if (httpContext.Request.Query.Any(p => p.Key == "Status"))
            {
                await httpContext.Response.WriteAsync("Working...");
            }
        }
    }

    // Clase para usar en el archivo principal (Program.cs)
    public static class StatusMiddlewareExtension
    {
        public static IApplicationBuilder UseStatusMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<StatusMiddleware>();
        }
    }
}
