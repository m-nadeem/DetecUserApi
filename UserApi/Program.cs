using Microsoft.Extensions.DependencyInjection;
using UserApi.UserApp;
using UserApi.UserApp.Services;

var builder = WebApplication.CreateBuilder(args);

var environment = builder.Environment;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44361") });
builder.Services.AddScoped<UserService>();

builder.Services.AddAntiforgery();
builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseRouting();
app.UseAntiforgery();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        //pattern: "{controller}/{id?}");
//        pattern: "{controller}/{action=Index}/{id?}");
//});

app.Run();
