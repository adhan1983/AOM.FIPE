using AOM.FIPE.API.Extensions;
using Microsoft.OpenApi.Models;
using System.Reflection;

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddingFIPEExtensions(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddingSwaggerGenExtensions(builder.Configuration);

#endregion

#region App

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion
