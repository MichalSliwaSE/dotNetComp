using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.CompilerServices;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseStaticFiles();
//enable routing
app.UseRouting();


//create endpoints
app.UseEndpoints(endpoints =>
{
    endpoints.Map("files/{filename}.{extension}", async context =>
    {
        string? filename = Convert.ToString(context.Request.RouteValues["filename"]);
        string? extension = Convert.ToString(context.Request.RouteValues["extension"]);
        await context.Response.WriteAsync($"In files - {filename} - {extension}");
    });
});

app.UseEndpoints(endpoints =>
{
    endpoints.Map("products/details/{id:length(1,3):int?}", async context =>
    {
        if (context.Request.RouteValues.ContainsKey("id"))
        {
            int? id = Convert.ToInt32(context.Request.RouteValues["id"]);
            await context.Response.WriteAsync($"Product details id:  - {id}");
        }
        else await context.Response.WriteAsync($"Id not provided");
    });
});

app.UseEndpoints(endpoints =>
{
    endpoints.Map("weather/{date:datetime?}", async context =>
    {
        DateTime date = Convert.ToDateTime(context.Request.RouteValues["date"]);
        await context.Response.WriteAsync($"Date is {date.ToShortDateString()}");
    });
});

app.UseEndpoints(endpoints =>
{
    endpoints.Map("cities/{cityid=guid}", async context =>
    {
         Guid cityId = Guid.Parse(Convert.ToString(context.Request.RouteValues["cityid"]!));
        await context.Response.WriteAsync($"City info :  {cityId}");
    });
});


app.Run(async context => { await context.Response.WriteAsync($"City information:  {context.Request.Path}"); });
app.Run();