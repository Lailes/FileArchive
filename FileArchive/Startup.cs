using System;
using FileArchive.Models;
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

        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);
            
            services.AddDbContext<IdentityContext>(opt => opt.UseSqlServer(_configuration[IdentityConfig]));
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();
            
            services.AddMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                SeedUser.EnsurePopulate(app);
            }

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseStaticFiles();

            
            app.UseMvc(options =>
            {
                options.MapRoute(name: "default", template: "{controller=Home}/{action=Index}");
            });
        }
    }
}