var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOrchardCms();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseStaticFiles();
app.UseOrchardCore();

app.Run();