using CartApi.Data;

using StackExchange.Redis;


var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<ICartRepository,RedisCartRepository>();
builder.Services.AddSingleton<ConnectionMultiplexer>(cm =>
{
    var config = ConfigurationOptions.Parse(
                      configuration["ConnectionString"], true);
    config.ResolveDns = true;
    config.AbortOnConnectFail = true;
    return ConnectionMultiplexer.Connect(config);

});

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