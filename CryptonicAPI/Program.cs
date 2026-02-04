var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapOpenApi();

app.MapGet("/", () => "CryptonicAPI är igång! 🚀");

// app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

app.Run();
