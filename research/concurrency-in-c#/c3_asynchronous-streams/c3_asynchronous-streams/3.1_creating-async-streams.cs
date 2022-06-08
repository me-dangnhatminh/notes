using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c3_asynchronous_streams
{
    internal class CreatingAsynchronousStreams
    {
        public static async IAsyncEnumerable<int> GetValuesAsync()
        {
            await Task.Delay(1000); // some asynchronous work
            yield return 10;
            await Task.Delay(1000); // more asynchronous work
            yield return 13;
        }
        public static async Task Run()
        {
            IAsyncEnumerable<int> values = GetValuesAsync();

        }
    }
}
