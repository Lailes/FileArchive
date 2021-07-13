using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FileArchive.Models
{
    public static class SeedUser
    {
        private const string User = "Auriel";
        private const string Password = "Root123$";
        
        public static void EnsurePopulate(IApplicationBuilder builder)
        {
            var service = builder.ApplicationServices.GetService<UserManager<IdentityUser>>();

            if (service == null)
            {
                throw new Exception("User manager is not registered");
            }

            if (!service.Users.Any())
            {
                service.CreateAsync(new IdentityUser(User), Password);
            }
        }
    }
}