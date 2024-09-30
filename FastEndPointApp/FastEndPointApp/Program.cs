using FastEndpoints;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDocument();

var app = builder.Build();


app.UseOpenApi();    // Serves the OpenAPI/Swagger documents
app.UseSwaggerUi(); // Serves the Swagger UI

// Configure the HTTP request pipeline.
app.UseFastEndpoints();

//app.UseHttpsRedirection();

app.Run();