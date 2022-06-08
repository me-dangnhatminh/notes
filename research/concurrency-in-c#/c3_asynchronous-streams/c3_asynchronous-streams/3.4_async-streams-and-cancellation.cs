using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace c3_asynchronous_streams
{
    internal class AsynchronousStreamsandCancellation
    {
        // Produce sequence that slows down as it progresses.
        public static async IAsyncEnumerable<int> SlowRange()
        {
            for (int i = 0; i != 10; ++i)
            {
                await Task.Delay(i * 100);
                yield return i;
            }
        }

        /*
         * Với thuộc tính tham số EnumeratorCancellation, trình biên dịch sẽ xử lý việc chuyển mã token từ WithCancellation đến token param được tạo bởi EnumeratorCancellation,
         * và yêu cầu hủy hiện đang chờ đợi OperationCanceledException  sau khi đã xử lý một số mục tiêu
         */
        public static async IAsyncEnumerable<int> SlowRange([EnumeratorCancellation] CancellationToken token = default)
        {
            for (int i = 0; i != 10; ++i)
            {
                await Task.Delay(i * 100, token);
                yield return i;
            }
        }

        public static async Task ConsumeSequence(IAsyncEnumerable<int> items)
        {
            using var cts = new CancellationTokenSource(500);
            CancellationToken token = cts.Token;
            await foreach (int result in items.WithCancellation(token).ConfigureAwait(false))
            {
                Console.WriteLine(result);
            }
        }

        public static async Task Run()
        {
            await foreach (int result in SlowRange().ConfigureAwait(false))
            {
                Console.WriteLine(result);
                if (result >= 7)
                    break; // Điều này sẽ dừng hoàn toàn cả 2 stream
            }
            await ConsumeSequence(SlowRange());
        }
    }
}
