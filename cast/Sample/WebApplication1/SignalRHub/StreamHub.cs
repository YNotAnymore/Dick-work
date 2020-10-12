using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace WebApplication1.SignalRHub
{
    public class StreamHub : Hub
    {

        /*
         
        js 执行:

        {"arguments":[500],"invocationId":"1","streamIds":[],"target":"DelayCounter","type":4}
         
         */

        // 服务端到客户端的流式传输
        public ChannelReader<int> DelayCounter(int delay)
        {
            var channel = Channel.CreateUnbounded<int>();

            _ = WriteItems(channel.Writer, 20, delay);

            return channel.Reader;
        }

        private async Task WriteItems(ChannelWriter<int> writer, int count, int delay)
        {
            for (var i = 0; i < count; i++)
            {
                await writer.WriteAsync(i);
                await Task.Delay(delay);
            }

            writer.TryComplete();
        }

        /*
         js 执行：

{"arguments":[],"streamIds":["0"],"target":"UploadStream","type":1}
15:12:46.536
{"invocationId":"0","item":"1","type":2}	41	
15:12:47.050
{"invocationId":"0","item":"2","type":2}	41	
15:12:47.547
{"invocationId":"0","item":"3","type":2}	41	
15:12:48.045
{"invocationId":"0","item":"4","type":2}	41	
15:12:48.550
{"invocationId":"0","item":"5","type":2}	41	
15:12:49.044
{"invocationId":"0","item":"6","type":2}	41	
15:12:49.539
{"invocationId":"0","item":"7","type":2}	41	
15:12:50.041
{"invocationId":"0","item":"8","type":2}	41	
15:12:50.540
{"invocationId":"0","item":"9","type":2}	41	
15:12:51.051
{"invocationId":"0","item":"10","type":2}	42	
15:12:51.552
{"invocationId":"0","typ
         
         */

        // 客户端到服务端的流式传输
        public async Task UploadStream(ChannelReader<string> stream)
        {
            while (await stream.WaitToReadAsync())
            {
                while (stream.TryRead(out var item))
                {
                    // do something with the stream item
                    Console.WriteLine(item);
                }
            }
        }

    }
}
