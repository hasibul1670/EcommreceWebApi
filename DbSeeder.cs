using Bogus;
using Microsoft.EntityFrameworkCore;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext db)
    {
        await db.Database.MigrateAsync();

        if (await db.Categories.AnyAsync())
            return;

        var categories = new Faker<Category>()
            .RuleFor(x => x.CategoryId, _ => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Commerce.Categories(1)[0])
            .RuleFor(x => x.Description, f => f.Lorem.Sentence())
            .RuleFor(x => x.CreatedAt, _ => DateTime.UtcNow)
            .Generate(100);

        var products = new Faker<Product>()
            .RuleFor(x => x.ProductId, _ => Guid.NewGuid())
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.CategoryId, f => f.PickRandom(categories).CategoryId)
            .Generate(100);

        db.Categories.AddRange(categories);
        db.Products.AddRange(products);

        await db.SaveChangesAsync();
    }
}