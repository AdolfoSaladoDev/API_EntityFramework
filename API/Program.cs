using Microsoft.EntityFrameworkCore;
using API.Context;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore.SqlServer;

var conexion = "Server=WINAPOHGECOCLWC\\SQLEXPRESS;Database=Restaurant;Integrated Security=True";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<MenuContext>(options => 
    options.UseSqlServer(conexion));

builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
endpoints.MapControllers(); });

app.Run();
