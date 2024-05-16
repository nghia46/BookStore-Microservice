using BookStore.BookService.Commands;
using BookStore.BookService.Domain.Interface;
using BookStore.BookService.Infrastructure.Repositories;
using BookStore.BookService.Queries;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

#region addedService
builder.Services.AddSingleton<IMongoClient, MongoClient>(s =>
{
    var uri = s.GetRequiredService<IConfiguration>()["MongoDb:LocalConnectionString"];
    return new MongoClient(uri);
});
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddQueries();
builder.Services.AddCommands();
#endregion

#region  defaultService
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();