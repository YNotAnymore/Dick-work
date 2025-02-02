using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

namespace GrpcService2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {

                    // ����http2Э��[���� grpc.AspNetCore]
                    //webBuilder.UseKestrel(options =>
                    //{
                    //     options.ConfigureEndpointDefaults(options2 =>
                    //     {
                    //         options2.Protocols = HttpProtocols.Http2;
                    //     });
                    //});

                    // ʹ��http
                    //webBuilder.UseKestrel(options =>
                    //{
                    //    options.Listen(IPAddress.Loopback, 5001);
                    //});
                    webBuilder.UseStartup<Startup>();
                });
    }
}
