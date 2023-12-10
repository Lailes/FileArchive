using FileArchive.Models.Account;
using FileArchive.Models.Dummies;
using FileArchive.Models.File;
using FileArchive.Models.File.Implementations;
using FileArchive.Models.File.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FileArchive;

public class Startup
{
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration) => _configuration = configuration;

    public void ConfigureServices (IServiceCollection services)
    {
        services.AddMvc(options => options.EnableEndpointRouting = false);
        
        services.AddDbContext<IdentityContext>(opt =>
        {
            var db = _configuration["AUTH_DB"];
            var host = _configuration["AUTH_DB_HOST"];
            var port = _configuration["AUTH_DB_PORT"];
            var user = _configuration["AUTH_DB_USER"];
            var password = _configuration["AUTH_DB_USER_PASSWORD"];
            var connectionString = $"Host={host};Port={port};Database={db};Username={user};Password={password}";
            
            opt.UseNpgsql(connectionString);
        });

        services.AddDbContext<ApplicationContext>(options =>
        {
            var db = _configuration["APP_DB"];
            var host = _configuration["APP_DB_HOST"];
            var port = _configuration["APP_DB_PORT"];
            var user = _configuration["APP_DB_USER"];
            var password = _configuration["APP_DB_USER_PASSWORD"];
            options.UseNpgsql($"Host={host};Port={port};Database={db};Username={user};Password={password}");
        });

        services.AddIdentity<FileArchiveUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            
        services.AddSingleton(_ => new SpaceProvider()
                                   .AddStatus("Default", 0, 5352980480)
                                   .AddStatus("Privileged", 1, 53529804800));
            
        services.AddSingleton(_ => new FileSystemProviderOptions(_configuration["FILE_PATH"]));
        services.AddScoped<IFileDetailProvider, FileDetailProvider>();
        services.AddScoped<IFileSystemProvider, FileSystemProvider>();
        services.AddScoped<IFileManager, FileManager>();
        services.AddScoped<IUserLevelProvider, IdentityContext>();

        services.AddMemoryCache();
        services.AddSession();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure (IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            SeedUser.EnsurePopulate(app);
        }
        else app.UseExceptionHandler("/Error");

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseStaticFiles();
        app.UseSession();

        app.UseMvc(options => options.MapRoute("default", "{controller=Home}/{action=Index}"));
    }
}