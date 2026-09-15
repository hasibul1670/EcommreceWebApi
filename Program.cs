var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();
app.MapGet("/", () => { return "based URL.."; });
app.MapGet("/hello", () =>
{
    return "Hello from get endpoint:(/hello)";
});

app.MapGet("/p/{id}", (int id) =>
{
    return $"hello text p {id}";
});
app.Run();



