namespace MiddlewareExample.CustomMiddleware;

public class HelloCustomMiddleware
{
    private readonly RequestDelegate _next;

    public HelloCustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Query.ContainsKey(("firstname")) && context.Request.Query.ContainsKey("lastname"))
        {
            string fullName = context.Request.Query["firstname"] + " " + context.Request.Query["lastname"] + "\n";
            await context.Response.WriteAsync(fullName);
        }
        await _next(context);
        //after logic
    }
}

public static class HelloCustomMiddleExtensions
{
    //extension method injecting UseHelloCustomMiddleware method into app object
    public static IApplicationBuilder UseHelloCustomMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HelloCustomMiddleware>();
    }
}