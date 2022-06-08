using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
        public static async IAsyncEnumerable<string> GetStringsAsync(HttpClient client)
        {
            int offset = 0;
            const int limit = 10;
            while (true)
            {
                // Get the current page of results and parse them.
                string result = await client.GetStringAsync(
                    $"https://example.com/api/values?offset={offset}&limit={limit}");
                string[] valuesOnThisPage = result.Split();

                // Produce the results for this page.
                foreach (string value in valuesOnThisPage)
                    yield return value;

                // If this is the last page, we're done.
                if (valuesOnThisPage.Length != limit)
                    break;

                // Otherwise, proceed to the next page.
                offset += limit;
            }
        }

        public static async Task Run()
        {
        }
    }
}
