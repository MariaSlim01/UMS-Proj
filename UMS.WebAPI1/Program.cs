
using System.Reflection;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.OData;

using UMS.Infrastructure.Abstraction.Mail;
using UMS.Infrastructure.Mail;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using System;
using System.Reflection;
using Autofac.Core;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using UMS.Application1.Hubs;
using UMS.Application1.IService;
//using UMS.Application1.Service;
using UMS.Domain.Tenant;
using UMS.WebAPI1;
using WebApplication4.Models;
using Wei.Abp.Chat;
;


var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(outputTemplate:"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}")
    //.Filter.ByIncludingOnly(o=>o.Level.Equals(LogEventLevel.Information))
    //.MinimumLevel.Warning()
    .CreateBootstrapLogger();
builder.Host.UseSerilog();

// Add services to the container.

//builder.Services.AddTransient<MailSettings>();

builder.Services.AddRazorPages();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.Load("UMS.Application1"));
//builder.Services.AddMediatR(typeof(CourseCreateCommand).GetTypeInfo().Assembly);
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());

builder.Services.AddMediatR(AppDomain.CurrentDomain.Load("UMS.Application1")); 
//builder.Services.AddControllers().AddOData(options => options.Select().Filter().OrderBy());

builder.Services.AddTransient<postgresContext>();


// builder.Services.AddTransient(
//     typeof(ITenantSetter));
//
// builder.Services.AddTransient(
//     typeof(ITenantGetter));
//
// builder.Services.AddTransient(
//     typeof(TenantService));

//builder.Services.AddScoped<MultiTenantServiceMiddleware>();



//builder.Services.AddScoped(typeof(IMapper),typeof(Mapper));


var config = builder.Configuration;

var mail_settings = new MailSettings();
config.Bind("MailSettings",mail_settings);
builder.Services.AddSingleton(mail_settings);

// var tenant = new List<Tenant>();
// config.Bind("Tenant", tenant);
//
//
// builder.Services.AddSingleton(tenant);

builder.Services.AddTransient<NotificationHub>();

builder.Services.AddSignalR();


builder.Services.AddScoped(typeof(IMailService), typeof(MailService));

ConfigureLogging();
builder.Host.UseSerilog();

Log.Information("Starting up");

builder.Host.UseSerilog();



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


app.MapGet("/", () => "Hello World!");

app.MapHub<NotificationHub>("/notificationHub");

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapHub("/NotificationHub");
// });



app.Run();

// foreach (var Tenant in tenant)
// {
//    
//     builder.Services.AddTransient(x => 
//         new postgresContext(new DbContextOptions<postgresContext>(),Tenant));
// }



// void ConfigureLogging()
// {
//     var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//     var configuration = new ConfigurationBuilder()
//         .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//         .AddJsonFile(
//             $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
//             optional: true)
//         .Build();
//
//     Log.Logger = new LoggerConfiguration()
//         .Enrich.FromLogContext()
//         .WriteTo.Debug()
//         .WriteTo.Console()
//         .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
//         .Enrich.WithProperty("Environment", environment)
//         .ReadFrom.Configuration(configuration)
//         .CreateLogger();
// }
//
// ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
// {
//     return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
//     {
//         AutoRegisterTemplate = true,
//         IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
//     };
// }
//
//  void CreateHost(string[] args)
// {
//     try
//     {
//         CreateHostBuilder(args).Build().Run();
//     }
//     catch (System.Exception ex)
//     {
//         Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
//         throw;
//     }
// }
//
//  IHostBuilder CreateHostBuilder(string[] args) =>
//     Host.CreateDefaultBuilder(args)
//         
//         .ConfigureAppConfiguration(configuration =>
//         {
//             configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
//             configuration.AddJsonFile(
//                 $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
//                 optional: true);
//         })
//         .UseSerilog();

void ConfigureLogging()
{
    var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
    var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile(
            $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
            optional: true)
        .Build();

    Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Debug()
        .WriteTo.Console()
        .WriteTo.Elasticsearch(ConfigureElasticSink(configuration, environment))
        .Enrich.WithProperty("Environment", environment)
        .ReadFrom.Configuration(configuration)
        .CreateLogger();
}

ElasticsearchSinkOptions ConfigureElasticSink(IConfigurationRoot configuration, string environment)
{
    return new ElasticsearchSinkOptions(new Uri(configuration["ElasticConfiguration:Uri"]))
    {
        AutoRegisterTemplate = true,
        IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower().Replace(".", "-")}-{environment?.ToLower().Replace(".", "-")}-{DateTime.UtcNow:yyyy-MM}"
    };
}

void CreateHost(string[] args)
{
    try
    {
        CreateHostBuilder(args).Build().Run();
    }
    catch (System.Exception ex)
    {
        Log.Fatal($"Failed to start {Assembly.GetExecutingAssembly().GetName().Name}", ex);
        throw;
    }
}

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        
        .ConfigureAppConfiguration(configuration =>
        {
            configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            configuration.AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
                optional: true);
        })
        .UseSerilog();


    
