using System;
using System.Linq;
using FileArchive.Models.Account;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace FileArchive.Models
{
    public static class SeedUser
    {
        private const string User = "Auriel";
        private const string Password = "Root123$";
        private const string Email = "Lutiaan@gmail.com";
        
        public static void EnsurePopulate(IApplicationBuilder builder)
        {
            var service = builder.ApplicationServices.GetService<UserManager<FileArchiveUser>>();

            if (service == null)
                throw new Exception("User manager is not registered");
            
            if (!service.Users.Any())
                service.CreateAsync(new FileArchiveUser {
                    Email = Email,
                    Name = User,
                    UserName = Email
                }, Password);
        }
    }
}