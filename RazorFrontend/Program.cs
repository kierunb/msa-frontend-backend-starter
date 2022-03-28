using Microsoft.Extensions.Configuration;
using RazorFrontend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddHttpClient<WeatherClient>(client =>
{
    //client.BaseAddress = builder.Configuration.GetServiceUri("WebApiBackend");  // requires 'Microsoft.Tye.Extensions.Configuration' library
    client.BaseAddress = new Uri(builder.Configuration["backendBaseUrl"]);    // hard-coded configuration
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
