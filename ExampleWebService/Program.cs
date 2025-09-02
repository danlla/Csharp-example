using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Word Storage API",
        Description = "Simple API to store and retrieve fantasy-themed words"
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Word Storage API v1");
    c.RoutePrefix = "swagger";
});

var strings = new List<string>
{
    "Whisperleaf",
    "Misthorn",
    "Glowspore"
};

app.MapGet("/api/words", () => Results.Ok(strings))
   .WithName("GetAllWords")
   .WithTags("Words")
   .WithDescription("Returns the list of all stored words.");

app.MapPost("/api/words", (string value) =>
{
    if (string.IsNullOrWhiteSpace(value))
        return Results.BadRequest("Query parameter 'value' is required and cannot be empty");

    strings.Add(value.Trim());
    return Results.Ok($"Word '{value}' added. Total words: {strings.Count}");
})
.WithName("AddWord")
.WithTags("Words")
.WithDescription("Adds a new word from the 'value' query parameter.");

app.Run();