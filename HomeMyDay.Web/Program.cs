using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace HomeMyDay.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) => 
            WebHost.CreateDefaultBuilder(args)
			.UseKestrel(options =>
			{
				var config = options.ApplicationServices.GetRequiredService<IConfiguration>();
				var certificateSettings = config.GetSection("Certificate");
				var certificate = new X509Certificate2(certificateSettings.GetValue<string>("Location"));
				options.Listen(IPAddress.Any, 44376, listenOptions =>
				{
					listenOptions.UseHttps(certificate);
				});
			})
			.UseStartup<Startup>()
			.Build();
    }
}
