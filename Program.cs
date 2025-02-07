using BlazorTaskManager.Components;
using BlazorTaskManager.Database;
using BlazorTaskManager.Services;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using Blazored.Modal;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("TabDB");

// Add MudBlazor services
builder.Services.AddMudServices();

// Add Blazored Modals servies
builder.Services.AddBlazoredModal();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Enable detailed errors
builder.Services.AddServerSideBlazor().AddCircuitOptions(options => options.DetailedErrors = true);

builder.Services.AddDbContextFactory<TabContext>(options => options.UseSqlite(connectionString));

builder.Services.AddTransient<TabService>();
builder.Services.AddTransient<TaskService>();

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
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
