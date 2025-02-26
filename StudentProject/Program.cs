using Microsoft.EntityFrameworkCore;
using StudentProject;
using StudentProject.Components;
using StudentProject.Components.Pages;
using StudentProject.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public partial class Program
{
    public static void Main(string[] args)
        => CreateHostBuilder(args).Build().Run();

    // EF Core uses this method at design time to access the DbContext
    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());
}

//public class Startup
//{
//    public void ConfigureServices(IServiceCollection services)
//    {
//        services.AddDbContext<StudentContext>(options =>
//            options.UseSqlite("Data Source=Database.db"));
//        services.AddRazorPages();
//        services.AddServerSideBlazor();
//    }

//}

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlite("Data Source=DataBase.db"));
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddScoped<Students>();
        services.AddScoped<Grades>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
    }
}

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    { }
    public DbSet<Student> Students { get; set; }
    public DbSet<Grade> Grades { get; set; }

}

//public class StudentContext : DbContext
//{
//    public StudentContext(DbContextOptions<StudentContext> options) : base(options)
//    {
//    }
//    public DbSet<Student> Students { get; set; }
//    public DbSet<Grade> Grades { get; set; }

//}