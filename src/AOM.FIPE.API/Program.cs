using AOM.FIPE.API.Extensions;
using AOM.FIPE.API.Extensions.FirebaseAuthentication;
using FirebaseAdmin;

#region Builder

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddingFIPEExtensions(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddingSwaggerGenExtensions(builder.Configuration);

builder.Services.AddSingleton(FirebaseApp.Create());

builder.Services.AddFirebaseAuthentication();

#endregion

#region App

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

#endregion
