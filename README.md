# File-Based .NET Apps

Single-file C# programs. Write code in one `.cs` file and run it—no solution or project setup.

## Quick Start
Create `hello.cs`:
```csharp
Console.WriteLine("Hello World");
```
Run:
```sh
dotnet run hello.cs
```
Add classes below top-level statements if needed.

## Directives (top of file)
```csharp
#:package Bogus@35.*        // NuGet package
#:sdk Microsoft.Net.Sdk.Web  // Web SDK (for APIs)
#:property Nullable enable   // Project property
```
One directive per line. Wildcards allow version ranges.

## Console Example
```csharp
#:package Bogus@35.*
using Bogus;

var faker = new Faker<Product>()
    .RuleFor(x => x.Id, f => f.Random.Guid())
    .RuleFor(x => x.CreatedAt, f => f.Date.Past())
    .RuleFor(x => x.Name, f => f.Commerce.ProductName())
    .RuleFor(x => x.Description, f => f.Commerce.ProductDescription())
    .RuleFor(x => x.Price, f => f.Random.Decimal());

foreach (var p in faker.Generate(5))
    Console.WriteLine($"{p.Name} ({p.Id})");

public sealed class Product
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}
```
Run:
```sh
dotnet run Wow.cs
```

## Minimal Web API
```csharp
#:sdk Microsoft.Net.Sdk.Web
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/hello", () => "Hello World");
app.Run();
```
Add Swagger:
```csharp
#:sdk Microsoft.Net.Sdk.Web
#:package Swashbuckle.AspNetCore@10.0.1
var b = WebApplication.CreateBuilder(args);
b.Services.AddEndpointsApiExplorer();
b.Services.AddSwaggerGen();
var app = b.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.MapGet("/hello", () => "Hello World");
app.Run();
```
Run:
```sh
dotnet run WowApi.cs
```

## Publish
```sh
dotnet publish app.cs
```

## Convert to Project
```sh
dotnet project convert app.cs
```
Generates a `.csproj` with detected directives.

## Why
Removes boilerplate. Faster learning & prototyping. Convert only when the app grows.

---
Build small. Iterate fast.
