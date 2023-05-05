using HierarchicalStructureOfDirectories.Data;
using HierarchicalStructureOfDirectories.Interfaces;
using HierarchicalStructureOfDirectories.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DirectoriesContext>(opt =>
{
	opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IRelationshipBetweenDirectyRepository, RelationshipBetweenDirectyRepository>();
builder.Services.AddScoped<IFileDirectoryRepository, FileDirectoryRepository>();


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

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=FileDirectory}/{action=Index}/{id?}");

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<DirectoriesContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
	await context.Database.MigrateAsync();
	await DirectoriesContextSeed.SeedAsync(context);
}
catch (Exception ex)
{
	logger.LogError(ex, "An error occured during migration");
}


app.Run();
