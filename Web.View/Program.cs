using Web.API.Client;

namespace Web.View;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddRazorPages();

        // Add MVC Controllers support
        builder.Services.AddControllersWithViews();

        // Update the API URL to the correct port
        builder.Services.AddHttpClient<IWebApiClient<string, Customer>, CustomerApiClient>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:7189/");
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.MapControllers();
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthorization();

        // Map endpoints for controllers
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        // Map endpoints for Razor Pages
        app.MapRazorPages()
           .WithStaticAssets();

        app.MapStaticAssets();

        app.Run();
    }
}
