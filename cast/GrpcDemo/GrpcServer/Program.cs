﻿using Grpc.Core;
using GrpcLibrary;
using System;
using System.Threading.Tasks;

namespace GrpcServer
{

    class GrpcImpl : GrpcService.GrpcServiceBase
    {
        // 实现SayHello方法
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Hello " + request.Name });
        }
    }

    class Program
    {

        const int Port = 10007;

        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { GrpcService.BindService(new GrpcImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("GrpcService server listening on port " + Port);
            Console.WriteLine("任意键退出...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
