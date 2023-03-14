using RugbyManager.Persistence;
using RugbyManager.Shared.Helpers;
using RugbyManager.Persistence.Extensions;
using System.Configuration;
using RugbyManager.Services.Extensions;

var builder = WebApplication.CreateBuilder(args);
ConfigurationHelper.Initialize(builder.Configuration);//read configurations
// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddRugbyManagerServices();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
