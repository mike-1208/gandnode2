﻿using Grand.Web.Admin.Extensions;
using Grand.Web.Common.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

Common.WwwRoot = "";

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseDefaultServiceProvider((_, options) =>
{
    options.ValidateScopes = false;
    options.ValidateOnBuild = false;
});

//use serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .Enrich.FromLogContext());

//add configuration
builder.Configuration.AddAppSettingsJsonFile(args);

//add services
Grand.Infrastructure.StartupBase.ConfigureServices(builder.Services, builder.Configuration);

builder.ConfigureApplicationSettings();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
}

//build app
var app = builder.Build();

//request pipeline
Grand.Infrastructure.StartupBase.ConfigureRequestPipeline(app, builder.Environment);

//run app
app.Run();
