using CommandService.Data;
using CommandsService.EventProcessing;
using CommandsService.Repositorie.Command;
using CommandsService.Repositorie.Platform;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CommandsConnection")));

builder.Services.AddTransient<ICommandRepo, CommandRepo>();
builder.Services.AddTransient<IPlatformRepo, PlatformRepo>();
builder.Services.AddTransient<IEventProcessor, EventProcessor>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
