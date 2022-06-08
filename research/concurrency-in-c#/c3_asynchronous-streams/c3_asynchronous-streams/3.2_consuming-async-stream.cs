using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c3_asynchronous_streams
{
    internal class ConsumingAsynchronousStreams
    {
        public static async IAsyncEnumerable<int> GetValueAsync(int max)
        {
            int offset = 0;
            const int limit = 1;
            //const int delayTime = 100;

            while (true)
            {
                yield return offset;
                //await Task.Delay(delayTime);

                if (offset >= max) break;
                offset += limit;
            }
        }

        public static async Task ProcessValueAsync()
        {
            IAsyncEnumerable<int> processingTask = GetValueAsync(100);
            await foreach (int value in processingTask.ConfigureAwait(false))
            {
                Console.Clear();
                Console.WriteLine(value + "%");
                const int delayTime = 100;
                await Task.Delay(delayTime);
            }
        }
        public static async Task Run()
        {
            ProcessValueAsync();
        }
    }
}
