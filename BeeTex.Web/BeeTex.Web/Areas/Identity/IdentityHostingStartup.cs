﻿
using Microsoft.AspNetCore.Hosting;


[assembly: HostingStartup(typeof(BeeTex.Web.Areas.Identity.IdentityHostingStartup))]
namespace BeeTex.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}