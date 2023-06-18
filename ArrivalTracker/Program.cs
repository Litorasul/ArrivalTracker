using ArrivalTracker.Data;
using ArrivalTracker.Data.Seeding;
using ArrivalTracker.DataAccessServices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new NullReferenceException("No ConnectionString in config!");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContextFactory<ArrivalsDbContext>((DbContextOptionsBuilder options) => options.UseSqlServer(connectionString));
builder.Services.AddTransient<IRoleDataAccessService, RoleDataAccessService>();
builder.Services.AddTransient<ITeamDataAccessService, TeamDataAccessService>();
builder.Services.AddTransient<IEmployeeDataAccessService, EmployeeDataAccessService>();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Seed data on application startup
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ArrivalsDbContext>();
    dbContext.Database.Migrate();

    ApplicationDbContextSeeder.Seed(dbContext, serviceScope.ServiceProvider);
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
