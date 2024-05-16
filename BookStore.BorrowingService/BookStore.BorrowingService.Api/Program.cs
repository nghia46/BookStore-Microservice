using BookStore.BorrowingService.Commands;
using BookStore.BorrowingService.Domain.Interface;
using BookStore.BorrowingService.Infrastructure.Repositories;
using BookStore.BorrowingService.Queries;
using MassTransit;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

#region addedService
builder.Services.AddSingleton<IMongoClient, MongoClient>(s =>
{
    var uri = s.GetRequiredService<IConfiguration>()["MongoDb:LocalConnectionString"];
    return new MongoClient(uri);
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddQueries();
builder.Services.AddCommands();
builder.Services.AddScoped<IBorrowingRequestRepository, BorrowingRequestRepository>();
#endregion

#region  defaultService
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region AMQP

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(new Uri("rabbitmq://guest:guest@localhost:5672"));

    });
});
// Add MassTransit hosted service
builder.Services.AddHostedService<MassTransitHostedService>();

#endregion

var app = builder.Build();

#region MassTransitHostedService

// Configure MassTransit bus control
var busControl = app.Services.GetRequiredService<IBusControl>();
await busControl.StartAsync();

#endregion


app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();