using ProjetoSeguroGarantia.API.Extensions;
using ProjetoSeguroGarantia.Application.Extensions;
using ProjetoSeguroGarantia.Domain.Extensions;
using ProjetoSeguroGarantia.Infra.Data.Extensions;
using ProjetoSeguroGarantia.Infra.Storage.Extensions;
//using ProjetoSeguroGarantia.Infra.Messages.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerDoc();
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddDataContext(builder.Configuration);
builder.Services.AddMongoDb(builder.Configuration);
//builder.Services.AddRabbitMQ(builder.Configuration);

var app = builder.Build();

app.UseSwaggerDoc();
app.UseAuthorization();
app.MapControllers();
app.Run();
