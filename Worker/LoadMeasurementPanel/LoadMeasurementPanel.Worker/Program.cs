using LoadMeasurementPanel.Worker;
using LoadMeasurementPanel.Worker.Extensions;
using LoadMeasurementPanel.Worker.Services;
using LoadMeasurementPanel.Worker.Services.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IFtpService, FtpService>();
builder.Services.AddApiConfiguration(builder.Configuration);

var host = builder.Build();
host.Run();
