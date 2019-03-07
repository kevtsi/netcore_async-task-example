using System;
using System.Threading;
using System.Threading.Tasks;

namespace tester.Scanners
{
    public interface IScanner
    {
        Task ExecuteAsync(CancellationToken cancellationToken);
    }
}
