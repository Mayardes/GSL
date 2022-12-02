using SISTEMALEGADO.BackgroundServices;
using SISTEMALEGADO.Data;
using SISTEMALEGADO.Model;
using SISTEMALEGADO.RabbitMQService;
using SISTEMALEGADO.Service;
using SISTEMALEGADO.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//ignora listas circulares
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//Instancia do Banco de Dados
builder.Services.AddDbContext<LegadoContext>();

builder.Services.AddScoped<RabbitMQPublisherService<Cliente>>();

builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Cliente>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Mercadoria>>();

builder.Services.AddScoped<INotificationServer<Cliente>, NotificationServer<Cliente>>();

builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<DepositoServices>();
builder.Services.AddScoped<FornecedorServices>();
builder.Services.AddScoped<MercadoriaServices>();


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
