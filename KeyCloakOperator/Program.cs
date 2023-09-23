using KeyCloakOperator.Entities;
using KeyCloakOperator.Extensions.MediatR;
using KeyCloakOperator.Managers;
using KubeOps.Operator;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddKubernetesOperator(s => s.EnableLeaderElection = false);
builder.Services.AddTransient<IManager<V1KeyCloakClientEntity>, TestManager>();
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
    cfg.AddOpenBehavior(typeof(LoggingBehavior<,>));
});
builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();
app.UseKubernetesOperator();
await app.RunOperatorAsync(args);
Log.CloseAndFlush();
