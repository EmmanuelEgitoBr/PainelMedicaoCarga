using LoadMeasurementPanel.Worker;
using LoadMeasurementPanel.Worker.Services;
using LoadMeasurementPanel.Worker.Services.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.Services.AddSingleton<IFtpService, FtpService>();

var host = builder.Build();
host.Run();
