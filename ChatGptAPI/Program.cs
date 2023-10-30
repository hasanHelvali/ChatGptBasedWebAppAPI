using ChatGptAPI.Services;
using Microsoft.Extensions.Options;
using OpenAI.GPT3.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<OpenAISohbetService>();
builder.Services.AddSingleton<OpenAIImageService>();
builder.Services.AddSingleton<OpenAIImageService>();
var apiKey = builder.Configuration["ApiKey"];
builder.Services.AddOpenAIService(settings => settings.ApiKey = apiKey);
builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
            //policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod()));
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()));

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
