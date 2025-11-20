#:package Bogus@35.*

using Bogus;
using System;

var faker = new Faker<Product>()
            .RuleFor(x => x.Id, f => f.Random.Guid())
            .RuleFor(x => x.CreatedAt, f => f.Date.Past())
            .RuleFor(x => x.Name, f => f.Commerce.ProductName())
            .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
            .RuleFor(x => x.Price, f => f.Random.Decimal());

var products = faker.Generate(10);

foreach(var product in products)
{
    Console.WriteLine($"Product: Id - {product.Id}, Name - {product.Name}");
}

public sealed class Product
{
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? ModifiedAt { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }
}