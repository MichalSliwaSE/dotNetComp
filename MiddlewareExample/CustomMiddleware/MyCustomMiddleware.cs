namespace MiddlewareExample.CustomMiddleware;

public class MyCustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("From custom first\n");
        await next(context);
        await context.Response.WriteAsync("end of my custom middleware\n");
    }
}

public static class CustomMiddlewareExtension
{   //extension method injecting DoSomething method into app object
    public static IApplicationBuilder UseMyCustomMiddleware(this IApplicationBuilder app)
    {
       return app.UseMiddleware<MyCustomMiddleware>();
    }
}