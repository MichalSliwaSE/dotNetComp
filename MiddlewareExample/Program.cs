using MiddlewareExample.CustomMiddleware;

var builder = WebApplication.CreateBuilder(args);
// builder.Services.AddTransient<MyCustomMiddleware>();
var app = builder.Build();

app.UseLoginMiddleware();
//middleware 1
// app.Use(async (HttpContext context, RequestDelegate next) =>
// {
//     await context.Response.WriteAsync("From 1st\n");
//     await next(context);
// });
//middleware 2
// app.UseMiddleware<MyCustomMiddleware>(); shorter version below using extension
// app.UseHelloCustomMiddleware();


//middleware 3 
// app.UseWhen(context => context.Request.Query.ContainsKey("username"), app =>
// {
//     app.Use(async (context, next) =>
//     {
//         await context.Response.WriteAsync("Middle3rdifname\n");
//         await next();
//         ;
//     });
// });
// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("3rd\n");
//     await next();
// });
//middleware 4
// app.Use(async (HttpContext context, RequestDelegate next) => { await context.Response.WriteAsync("Middle 4th\n"); });
app.Run(async context => {
    await context.Response.WriteAsync("No response");
});
app.Run();