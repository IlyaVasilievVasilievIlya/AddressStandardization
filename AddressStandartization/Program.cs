using AddressStandartization.Configuration;
using AddressStandartization.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.AddAppLogger();

var configuration = builder.Configuration;
var services = builder.Services;

services.AddAppCors();

services.Configure<DadataApiSettings>(configuration.GetSection("DadataApiSettings"));


services.AddControllers();


services.AddStandardizationService();
services.AddTransient<ApiHeadersMessageHandler>();

services.AddAppHttpClient(configuration.GetSection("DadataApiSettings").Get<DadataApiSettings>());

services.AddAppAutoMappers();

var app = builder.Build();


app.UseMiddleware<ExceptionsMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
