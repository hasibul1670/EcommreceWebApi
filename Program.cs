using Microsoft.AspNetCore.WebSockets;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
if (app.Environment.IsDevelopment()) // development e check korbe
{
    app.UseSwagger();//middleware
    app.UseSwaggerUI();
}


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
app.MapGet("/health", () => Results.Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow }));
app.MapPost("/post", () => { return "Hello POST Method"; });
app.Run();

