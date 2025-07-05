using AlexaLlamaApi.Interfaces;
using AlexaLlamaApi.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Register services
builder.Services.AddSingleton<IChatMemoryService, ChatMemoryService>();
// Register LlamaService with its dependencies
builder.Services.AddHttpClient(); // Register IHttpClientFactory
builder.Services.AddTransient<ILlamaService, LlamaService>(); // Register LlamaService
// builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

// Ensure all required services are registered
builder.Services.AddControllers(); // Add controllers for API endpoints
builder.Services.AddLogging(); // Add logging services

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();

// Existing code
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

// Add configuration from appsettings.json and environment variables
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                      .AddEnvironmentVariables();

var app = builder.Build();

// Configure middleware
app.UseHttpsRedirection();
app.UseAuthorization(); // Ensure authorization middleware is added if needed
app.MapControllers(); // Map controller routes

// Enable Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.Run();
