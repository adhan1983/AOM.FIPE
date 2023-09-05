using AOM.FIPE.FirebaseAuthentication.SDK.Extensions;
using AOM.FIPE.WebApp.Extensions;
using AOM.FIPE.WebApp.Extensions.Mappers;
using AOM.FIPE.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var firebaseConfigurations = FirebaseConfigurationsExtensions.BuildingFirebaseConfigurations(builder.Configuration);

builder.Services.AddFirebaseAuthenticationSDK(firebaseConfigurations);

builder.Services.AddingAutoMapper();

builder.Services.AddingSessionsExtensions();

builder.Services.AddScoped<IFIPEService, FIPEService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
