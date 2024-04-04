var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");



// Define route for handling math operations
app.MapGet("/calculate", async context =>
{
    // Extract query parameters from the request URL
    var query = context.Request.Query;
    if (query.TryGetValue("firstnumber", out var firstNumberStr) &&
        query.TryGetValue("secondnumber", out var secondNumberStr) &&
        query.TryGetValue("operation", out var operationStr))
    {
        if (double.TryParse(firstNumberStr, out double firstNumber) &&
            double.TryParse(secondNumberStr, out double secondNumber))
        {
            // Perform the math operation based on the provided operation
            double result;
            switch (operationStr)
            {
                case "add":
                    result = firstNumber + secondNumber;
                    break;
                case "subtract":
                    result = firstNumber - secondNumber;
                    break;
                case "multiply":
                    result = firstNumber * secondNumber;
                    break;
                case "divide":
                    // Check for division by zero
                    if (secondNumber != 0)
                    {
                        result = firstNumber / secondNumber;
                    }
                    else
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Error: Division by zero.");
                        return;
                    }
                    break;
                default:
                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                    await context.Response.WriteAsync("Error: Invalid operation.");
                    return;
            }

            // Return the result as the response
            await context.Response.WriteAsync($"Result: {result}");
        }
        else
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsync("Error: Invalid numbers.");
        }
    }
    else
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsync("Error: Missing query parameters.");
    }
});

app.Run();