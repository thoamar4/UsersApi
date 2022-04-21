using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using UsersApi.Models;

namespace UsersApi
{
    public class Program
    {
       
        public static void Main(string[] args)
        {
            var config = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();
           // var settings = config.GetSection("UserDatabaseSettings").Get<UserDatabaseSettings>();
            var host = WebHost.CreateDefaultBuilder()
                      .UseConfiguration(config)
                      .UseStartup<Startup>()
                      .Build();
           
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>();
    }
}
