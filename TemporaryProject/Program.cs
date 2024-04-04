var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");


string test = "test";
string test1 = "second";
Console.WriteLine(test);



app.Run();