using INFORMACOESCADASTRAIS.BackgroundServices;
using INFORMACOESCADASTRAIS.Data;
using INFORMACOESCADASTRAIS.Model;
using INFORMACOESCADASTRAIS.RabbitMQService;
using INFORMACOESCADASTRAIS.Service;
using INFORMACOESCADASTRAIS.Services;
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
builder.Services.AddScoped<RabbitMQPublisherService<Deposito>>();
builder.Services.AddScoped<RabbitMQPublisherService<Fornecedor>>();
builder.Services.AddScoped<RabbitMQPublisherService<Mercadoria>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Cliente>>();
builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Mercadoria>>();
builder.Services.AddScoped<INotificationServer<Cliente>, NotificationServer<Cliente>>();


//ignora listas circulares
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//API
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
