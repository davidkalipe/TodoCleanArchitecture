using MediatR;
using Microsoft.EntityFrameworkCore;
using Todo.Application;
using Todo.Application.Interfaces;
using Todo.Application.Repository;
using Todo.Application.Services;
using Todo.Infrastructure.Repository;
using Todo.Infrastructure;
using Todo.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddDbContext<TodoDbContext>(opt =>
    opt.UseNpgsql(builder.Configuration.GetConnectionString("TodoDbConnection")));
builder.Services.AddMediatR(typeof(Program));
builder.Services.AddApplication();
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