using ContactsManagement.Repositories;
using ContactsManagement.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register ContactsRepository and ContactsService
builder.Services.AddSingleton<ContactsRepository>();
builder.Services.AddSingleton<ContactsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();
app.MapControllers();

app.Run();
