using MongoDB.Driver;
using MongoDbTransactions.NET.Collections;
using MongoDbTransactions.NET.Dtos;
using MongoDbTransactions.NET.Services;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/Product", async (ProductDto dto) =>
{
    var client = new MongoClient(builder.Configuration.GetConnectionString("MongoDB"));
    var db = client.GetDatabase("shop");

    await db.CreateCollectionAsync("productInventory");

    var products = db.GetCollection<Product>("product");
    var productsInventory = db.GetCollection<ProductInventory>("productInventory");

    using var session = await client.StartSessionAsync();
    session.StartTransaction();
    try
    {
        var product = new Product { Name = dto.Name, Price = dto.Price };
        await products.InsertOneAsync(session, product);
        await productsInventory.InsertOneAsync(session, new() { Id = product.Id, Quantity = dto.Quantity });

        product.Images = new StorageService().UploadImages(dto.Base64Images);
        await products.ReplaceOneAsync(session, f => f.Id.Equals(product.Id), product);

        await session.CommitTransactionAsync();
        return Results.Ok(product);
    }
    catch (Exception e)
    {
        await session.AbortTransactionAsync();
        return Results.BadRequest($"Failed to create product. {e.Message}");
    }
});

app.Run();
