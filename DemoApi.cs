#:sdk Microsoft.Net.Sdk.Web

#:package Swashbuckle.AspNetCore@10.0.1

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/hello", () => Results.Text("Hello World!"));

app.Run();