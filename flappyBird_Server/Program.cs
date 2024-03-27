using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using flappyBird_Server.Data;
using flappyBird_Server.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<flappyBird_ServerContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("flappyBird_ServerContext"));
    options.UseLazyLoadingProxies();
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<flappyBird_ServerContext>();

var app = builder.Build();

// Ajouter les CORS ! 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
