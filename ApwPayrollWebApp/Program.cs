using ApwPayroll_Application.Extensions;
using ApwPayroll_Infrastructure.Extensions;
using ApwPayroll_Persistence.Extensions;
using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    })
    .AddRazorRuntimeCompilation();

builder.Services.AddPersistenceLayer(builder.Configuration);
builder.Services.AddApplicationLayer();
builder.Services.AddInfrastructureLayer(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddNotyf(config =>
{
    config.DurationInSeconds = 10;
    config.IsDismissable = true;
    config.Position = NotyfPosition.TopRight;
}
);
builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Administration/Denied";
    options.Cookie.Name = "AppCookie";
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(60);
    options.LoginPath = "/Administration/Login";
    options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
    options.SlidingExpiration = true;
});

builder.Services.AddSession(); // Add session services
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
