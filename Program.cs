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


app.MapGet("/", () => { return "Backend Server is ON...."; });

//Read Categories
app.MapGet("/api/categories", () =>
{
    return Results.Ok();
});




app.Run();



public record Category
{
    public Guid CategoryId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; }
}
public record Product
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}