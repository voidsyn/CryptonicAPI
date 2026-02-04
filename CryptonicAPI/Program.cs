var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

app.MapGet("/", () => "CryptonicAPI");

app.MapOpenApi();
app.UseAuthorization();
app.MapControllers();

app.Run();
