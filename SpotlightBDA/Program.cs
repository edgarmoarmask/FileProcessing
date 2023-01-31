using SpotlightBDA.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MudBlazor.Services;
using Microsoft.Extensions.DependencyInjection;
using SpotlightBDA.Core.Extensions;
using Blazored.LocalStorage;
using Blazored.Toast;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<ApplicationDbContext>(options => options
                    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped(sp => sp
                    .GetRequiredService<IHttpClientFactory>()
                    .CreateClient("asd"));
builder.Services.AddTransient<DbInitializer>(); 
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddHttpClient(
                    "asd",
                    client =>
                    {
                        client.BaseAddress = new Uri("http://192.168.0.61:9870");
                        //client.DefaultRequestHeaders.Add("secccc", "nocors");
                    }
                    );
builder.Services.AddBlazoredToast();
builder.Services.AddMudServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Initialize();
app.Run();
