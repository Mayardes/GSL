using CALCULOFRETE.BackgroundServices;
using CALCULOFRETE.Data;
using CALCULOFRETE.Model;
using CALCULOFRETE.RabbitMQService;
using CALCULOFRETE.Service;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//Instancia do Banco de Dados
builder.Services.AddDbContext<FreteClienteDBContext>();

builder.Services.AddControllers();

builder.Services.AddScoped<RabbitMQPublisherService<Cliente>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Cliente>>();
builder.Services.AddScoped<ClienteServices>();


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen(options => {
    options.ExampleFilters();
});


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
