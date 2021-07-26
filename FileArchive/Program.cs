using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace FileArchive
{
    public class Program
    {
        public static void Main (string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder (string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                       .UseDefaultServiceProvider(opt => opt.ValidateScopes = false)
                       .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }
    }
}