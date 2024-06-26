using System.Net;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Monotaur.Plugins.Dummy.Services;

var builder = WebApplication.CreateBuilder(args);

if (args.Length > 1)
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.Listen(IPAddress.Any, int.Parse(args[1]), listenOptions =>
        {
            listenOptions.Protocols = HttpProtocols.Http2;
        });
    });
}

// Add services to the container.
builder.Services.AddGrpc();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<ProbeService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();