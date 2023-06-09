﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoreWCF.Configuration;

namespace NetTcpWithIISServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseIISIntegration().UseKestrel(it =>
            {
                it.ListenLocalhost(5000);
            }).UseNetTcp(5005).UseStartup<Startup>();
    }
}
