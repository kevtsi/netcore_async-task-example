using System;
using System.Threading;
using System.Threading.Tasks;
using tester.Models;

namespace tester.Scanners
{
    public class TestScan : IScanner
    {
        const string FILE_NAME = "test.json";

        public async Task ExecuteAsync(CancellationToken cancellationToken) 
        {
            Console.WriteLine("Performing test scan");
            await Task.Delay(12000);
            var obj = new Test()
            {
                Key = "Test01"
            };

            if (!cancellationToken.IsCancellationRequested)
            {
                await Jsonify.SerializeToFile(FILE_NAME, obj);
                Console.WriteLine("Test scan complete");
            }
            else
            {
                Console.WriteLine("Test scan cancelled!");
            }

        }

    }
}
