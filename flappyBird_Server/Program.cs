using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using flappyBird_Server.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<flappyBird_ServerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("flappyBird_ServerContext") ?? throw new InvalidOperationException("Connection string 'flappyBird_ServerContext' not found.")));

// Add services to the container.

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
