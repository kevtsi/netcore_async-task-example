using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using tester.Scanners;

namespace tester
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Scan Test...\n");

            var actions = ParseArgs(args);
            if (actions.Count == 0)
            {
                Console.WriteLine("Nothing to do.. exiting");
                return 1;
            }

            Task.Run(async () => {

                List<IScanner> scanners = new List<IScanner>();
                if (actions.Contains("testScan"))
                    scanners.Add(new TestScan());
                if (actions.Contains("networkScan"))
                    scanners.Add(new NetworkScan());

                List<Task> tasks = new List<Task>();
                foreach (var scanner in scanners)
                {
                    var task = scanner.ExecuteAsync(CancellationToken.None);
                    tasks.Add(task);
                }
                await Task.WhenAll(tasks.ToArray());

            }).Wait();

            Console.WriteLine("\nDone");
            return 0;

        }

        static List<string> ParseArgs(string[] args)
        {
            List<string> actions = new List<string>();
            foreach (string arg in args)
            {
                switch (arg.ToUpper())
                {
                    case "/NETWORKSCAN":
                        actions.Add("networkScan");
                        break;
                    case "/TESTSCAN":
                        actions.Add("testScan");
                        break;
                }
            }
            return actions;
        }

    }


}
