using Grpc.Net.Client;
using GrpcService2;
using System;
using System.Threading.Channels;

namespace GrpcClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            GrpcChannel channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);

            var input = "test";
            var reply = client.SayHello(new HelloRequest { Name = null });
            Console.WriteLine("来自" + reply.Message);

            channel.ShutdownAsync().Wait();
            Console.WriteLine("任意键退出...");
            Console.ReadKey();
        }
    }
}
