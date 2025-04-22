using TaskManagerApi.Application.Services;
using TaskManagerApi.Domain.Interfaces;
using TaskManagerApi.Infrastructure.Data;
using TaskManagerApi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using TaskManagerApi.Application.Mappings;
using TaskManagerApi.Application.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// SQLite connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=taskmanager.db"));

builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<TaskService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();

builder.Services.AddValidatorsFromAssemblyContaining<CreateAppTaskValidator>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
