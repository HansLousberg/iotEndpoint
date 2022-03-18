using iotEndpoint;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

//var mqttFactory = new MqttFactory();
//var mqttClient = mqttFactory.CreateMqttClient();
MQTTclient mQTTclient = new MQTTclient();
await mQTTclient.Connect_Client();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
