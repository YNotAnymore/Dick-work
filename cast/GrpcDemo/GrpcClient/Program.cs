using Grpc.Core;
using GrpcLibrary;
using System;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Channel channel = new Channel("127.0.0.1:10007", ChannelCredentials.Insecure);

            var client = new GrpcService.GrpcServiceClient(channel);

            var input = "test";
            var reply = client.SayHello(new HelloRequest { Name = input });
            Console.WriteLine("来自" + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
