using System;
using System.Threading;
using System.Threading.Tasks;
using tester.Models;

namespace tester.Scanners
{
    public class NetworkScan : IScanner
    {
        const string FILE_NAME = "network.json";

        public async Task ExecuteAsync(CancellationToken cancellationToken) 
        {
            Console.WriteLine("Performing network scan");
            await Task.Delay(5000);
            var obj = new NetworkInfo()
            {
                HostName = "Testhost001",
                IP = "127.0.0.1"
            };
            if (!cancellationToken.IsCancellationRequested) 
            {
                await Jsonify.SerializeToFile(FILE_NAME, obj);
                Console.WriteLine("Network scan complete");
            }
            else 
            {
                Console.WriteLine("Network scan cancelled!");
            }

        }

    }
}
