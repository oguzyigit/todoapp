var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();


List<string> todoItems = new List<string>() {"aa","bb"};
app.MapGet("/", () => "Hello World!");
app.MapGet("/todos", async (http) => {
    await http.Response.WriteAsJsonAsync(todoItems);
});
//no need for async
app.MapPost("/todos", (string todoItem) =>
{
    todoItems.Add(todoItem);
    return Results.Ok(todoItems);
});

app.Run();
