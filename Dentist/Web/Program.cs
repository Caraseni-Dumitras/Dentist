using Infrastructure;
using Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("AppData/appsettings.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile("AppData/appsettings.Local.json", optional: true, reloadOnChange: true);
builder.Configuration.AddJsonFile("AppData/appsettings.Development.json", optional: true, reloadOnChange: true);

// configure layers
builder.Services.ConfigureInfrastructure(builder.Configuration);

builder.Services.AddControllersWithViews();

var app = builder.Build();

// insert client and admin roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userRoleService = services.GetRequiredService<IUserRoleService>();
    await userRoleService.InsertApplicationRolesAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();