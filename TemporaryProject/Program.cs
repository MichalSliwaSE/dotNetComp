var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


string test = "test";
Console.WriteLine(test);



app.Run();