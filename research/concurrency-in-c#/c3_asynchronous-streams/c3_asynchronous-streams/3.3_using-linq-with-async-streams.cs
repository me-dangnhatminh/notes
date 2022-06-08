using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c3_asynchronous_streams
{
    /* Các toán tử LINQ cho các luồng không đồng bộ nằm trong gói NuGet dành cho System.Linq.Async.
     * Các toán tử LINQ bổ sung cho các luồng không đồng bộ có thể được tìm thấy trong gói NuGet cho System.Interactive.Async.
     */
    internal class UsingLINQwithAsynchronousStreams
    {
        public static async Task Run()
        {
            IAsyncEnumerable<int> values = SlowRange().WhereAwait(async value => // Tương đương với sử dụng where -> vẫn tạo ra một async stream
            {
                await Task.Delay(10);
                return value % 2 == 0; // Lọc ra các giá trị chia hết cho 2
            });



            await foreach (int value in values.ConfigureAwait(false))
            {
                Console.WriteLine(value);
            }

            async IAsyncEnumerable<int> SlowRange()
            {
                for (int i = 0; i != 10; ++i)
                {
                    await Task.Delay(i * 100);
                    yield return i;
                }
            }

            int count = await SlowRange().CountAsync( value => value % 2 == 0);
            // Return 5 và mất i * 100 để lấy kết quả
            // Nghĩa là tại đây nó sẽ chạy SlowRange luôn chứ k nhử ở trên phải vào foreach mới chạy
            Console.WriteLine(count);

            // Kiểu này tương tự như CountAsync, khác nhau là ở đây có thể dùng async ở trong func lumbda
            int count1 = await SlowRange().CountAwaitAsync(async value => {
                await Task.Delay(10);
                return value % 2 == 0;
            });
        }
    }
}
