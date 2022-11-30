using RASTREIOMERCADORIAS.BackgroundServices;
using RASTREIOMERCADORIAS.Data;
using RASTREIOMERCADORIAS.Model;
using RASTREIOMERCADORIAS.RabbitMQService;
using RASTREIOMERCADORIAS.Service;
using RASTREIOMERCADORIAS.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Instancia do Banco de Dados
builder.Services.AddDbContext<CadastroContext>();

//Instancia dos serviços
builder.Services.AddScoped<ClienteServices>();
builder.Services.AddScoped<DepositoServices>();
builder.Services.AddScoped<FornecedorServices>();
builder.Services.AddScoped<MercadoriaServices>();


//Chamar o serviço do outro módulo no RabbitMQ
builder.Services.AddScoped<RabbitMQPublisherService<Cliente>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Cliente>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Deposito>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Fornecedor>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Mercadoria>>();

builder.Services.AddScoped<INotificationServer<Cliente>, NotificationServer<Cliente>>();
builder.Services.AddScoped<INotificationServer<Deposito>, NotificationServer<Deposito>>();
builder.Services.AddScoped<INotificationServer<Fornecedor>, NotificationServer<Fornecedor>>();
builder.Services.AddScoped<INotificationServer<Mercadoria>, NotificationServer<Mercadoria>>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

//API
builder.Services.AddEndpointsApiExplorer();

//Swagger
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());
builder.Services.AddSwaggerGen(options => {
    options.ExampleFilters();
});

//ignora listas circulares
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
