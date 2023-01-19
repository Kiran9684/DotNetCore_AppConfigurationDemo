using DotNetCore_AppConfigurationDemo.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Binding and adding Position section config data from app settings.json file to dependency injection service container.
//In the following code, PositionOptions is added to the service container with Configure and bound to configuration:
builder.Services.Configure<PositionOptions>(builder.Configuration.GetSection(PositionOptions.Position));


//The following code adds MySubsection.json to the configuration providers:
builder.Configuration.AddJsonFile("D:\\DotNet WorkSpace\\Workspace\\Visual Studio Workspace\\CORE_WebAppConfigurationDemo\\DotNetCore_AppConfigurationDemo\\CustomConfigs\\MySubsection.json", optional: false, reloadOnChange: true);
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
    pattern: "{controller=Test}/{action=Index}/{id?}");

app.Run();
