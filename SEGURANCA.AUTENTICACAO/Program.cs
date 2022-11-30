using SEGURANCAAUTENTICACAO.BackgroundServices;
using SEGURANCAAUTENTICACAO.Data;
using SEGURANCAAUTENTICACAO.Model;
using SEGURANCAAUTENTICACAO.RabbitMQService;
using SEGURANCAAUTENTICACAO.Service;
using SEGURANCAAUTENTICACAO.Services;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


//ignora listas circulares
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

//Instancia do Banco de Dados
builder.Services.AddDbContext<LoginContext>();

builder.Services.AddScoped<RabbitMQPublisherService<Usuario>>();
//builder.Services.AddHostedService<RabbitMQBackgroundConsumerService<Usuario>>();
builder.Services.AddScoped<INotificationServer<Usuario>, NotificationServer<Usuario>>();

builder.Services.AddScoped<UsuarioServices>();


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
