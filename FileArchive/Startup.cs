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

namespace FileArchive
{
    public class Startup
    {
        private const string IdentityConfig = "Identity:ConnectionString";
        private const string MsSqlConfig = "MsSqlConfig:ConnectionString";
        private const string RootPath = @"Storage:RootPath";

        private readonly IConfiguration _configuration;

        public Startup (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices (IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<IdentityContext>(opt => opt.UseSqlServer(_configuration[IdentityConfig]));
            services.AddIdentity<FileArchiveUser, IdentityRole>()
                    .AddEntityFrameworkStores<IdentityContext>()
                    .AddDefaultTokenProviders();

            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(_configuration[MsSqlConfig]));

            services.AddScoped<IFileDetailProvider, FileDetailProvider>();
            services.AddScoped<IFileSystemProvider, FileSystemProvider>(_ => new FileSystemProvider(new FileSystemProviderOptions (_configuration[RootPath])));
            services.AddScoped<IFileManager, FileManager>();

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
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.UseSession();

            app.UseMvc(options => { options.MapRoute("default", "{controller=Home}/{action=Index}"); });
        }
    }
}