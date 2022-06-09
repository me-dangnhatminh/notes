#region 5.0 Dataflow basics
using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace c5_dataflow_basics
{
    /* TPL Dataflow là một thư viện mạnh mẽ cho phép bạn tạo một mesh hoặc pipiline và sau đó (asynchoronously) gửi data của bạn qua nó
     * Để sủ dụng TPL Dataflow, install package System.Threading.Tasks.Dataflow
     */
    class Program
    {
        static void Main(string[] args)
        {
            //LinkingBlocks.Run();
            //PropagatingErrors.Run();
            //UnlinkingBlocks.Run();
            ThrottlingBlocks.Run();
            Console.ReadKey();
        }
    }
}
#endregion

#region 5.1 Linking Blocks
/* 5.1 Linking Blocks (liên kết các khối)
 * Problem: Bạn cần liên kết các dataflow block với nhau để tạo mesh
 */
namespace c5_dataflow_basics
{
    class LinkingBlocks
    {
        public static async Task Run()
        {
            TransformBlock<int, int> multiplyBlock = new TransformBlock<int, int>(item => { Console.WriteLine(item * 2); return item * 2; });
            TransformBlock<int, int> subtractBlock = new TransformBlock<int, int>(item => { Console.WriteLine(item - 2); return item - 2; });

            /* Nếu dataflow là tuyến tính, thì bạn có thể sẽ muốn phỏ biến quá trình (complete or error).
             * Để làm điều đó, bạn có thể đặt PropagateCompoletion tùy chọn trên LinkTo.
             */
            var obtions = new DataflowLinkOptions { PropagateCompletion = true };

            /* Sau khi linking, các giá trị thoát ra khỏi multipleBlock sẽ nhập vào subtractBlock
             */
            //multiplyBlock.LinkTo(subtractBlock);
            multiplyBlock.LinkTo(subtractBlock, obtions);

            //...

            multiplyBlock.Complete();
            await subtractBlock.Completion;
        }
    }
}
#endregion

#region 5.2 Propagating Errors
/* 5.2 Propagating Errors (lỗi lan truyền)
 * Problem: Bạn cần một cách để phản hồi các lỗi có thể xảy ra trong lưới luồng dữ liệu của mình
 */
namespace c5_dataflow_basics
{
    class PropagatingErrors
    {
        public static async Task Run()
        {
            /* Bắt lỗi đơn thuần
             */
            //try
            //{
            //    var block = new TransformBlock<int, int>(item =>
            //    {
            //        if (item == 1) throw new InvalidOperationException("Blech.");
            //        return item * 2;
            //    });

            //    block.Post(1);
            //    await block.Completion; // Không có dòng này là try catch bên ngoài không thể bắt được lỗi
            //}
            //catch (InvalidOperationException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            /* Truyền lỗi
             */
            try
            {
                var multiplyBlock = new TransformBlock<int, int>(item =>
                {
                    Console.WriteLine(item); // return 1
                    if (item == 1) throw new InvalidOperationException("Blech.");
                    return item * 2;
                });

                var subtractBlock = new TransformBlock<int, int>(item =>
                {
                    Console.WriteLine(item); // return 2
                    if (item == 1) throw new InvalidOperationException("Blech.");
                    return item - 2;
                });
                multiplyBlock.LinkTo(subtractBlock, new DataflowLinkOptions { PropagateCompletion = true }); // khi return ở multiplyBlock thì dữ liệu đó sẽ được truyền cho subtractBlock
                multiplyBlock.Post(1);
                //await subtractBlock.Completion;
                await multiplyBlock.Completion;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
#endregion

#region 5.3 Unlinking Blocks
/* 5.1 Unlinking Blocks (Hủy liên kết các khối)
 * Problem: Trong quá trình xử lý, bạn cần thay đổi cấu trúc luồng dữ liệu của mình. Đây là kịch bản nâng cao
 * mà hầu như không cần thiết.
 * Solution:
 */
namespace c5_dataflow_basics
{
    class UnlinkingBlocks
    {
        /* Để thay đổi bộ lọc trên một liên kết hiện có,
         * bạn phải hủy liên kết cũ và tạo một liên kết mới với bộ lọc mới(option DataflowOptions.Append thành false)
         */
        public static async Task Run()
        {
            var multiplyBlock = new TransformBlock<int, int>(item => item * 2);
            var subtractBlock = new TransformBlock<int, int>(item => item - 2);

            IDisposable link = multiplyBlock.LinkTo(subtractBlock);
            multiplyBlock.Post(1);
            multiplyBlock.Post(2);

            // Bỏ liên kết các chuỗi
            // Data được đk có thể đã hoặc chưa đi qua link.
            // Trong mã thực tế, hãy xem xét một khối đang sử dụng thay vì gọi Dispose;
            link.Dispose();

            // Sau khi hủy vẫn có thể liên kết lại, nhưng phải bắt đầu lại từ đầu
            multiplyBlock.LinkTo(subtractBlock);
            multiplyBlock.Post(1);

        }
    }
}
#endregion

#region 5.4 Throttling Blocks
/* 5.1 Throttling Blocks (Khối điều chỉnh)
 * Problem: Ban có một kịch bản rẽ nhánh trong lưới luồng dữ liệu của mình và muốn dữ liệu chảy theo cách cân bằng tải (load-balancing)
 * Solution: By default, 
 */
namespace c5_dataflow_basics
{
    class ThrottlingBlocks
    {
        /* Theo mặc định BoundCapacity được đặt thành DataflowBlockOptions.Unbounded -> điều này khiến khối mục tiêu đầu tiên lưu
         * vào bộ đệm tất cả dữ liệu ngay cả khi nó chưa sẵn sàng để xử lý.
         * 
         * BoundCapacity có thể được đặt thành bất kỳ giá trị nào lớn hơn 0 (or tất nhiên, DataflowBlockOptions.Unbounded),
         * miễn là các block target có thể theo kịp dữ liệu đến từ các khối nguồn, giá trị đơn giản là 1 sẽ đủ.
         * 
         * Bằng cách sử dụng BoundedCapacity cho các block trong mesh, bạn sẽ không đọc quá nhiều dữ liệu I/O cho đến khi mesh của bạn sẵn sàng
         * và mesh của bạn sẽ không kết thúc việc lưu vào bộ đệm tất cả dữ liệu đầu vào trước khi có thể xử lý.
         */
        public static async Task Run()
        {
            var sourceBlock = new BufferBlock<int>();
            var options = new DataflowBlockOptions { BoundedCapacity = 1 };
            var targetBlockA = new BufferBlock<int>(options);
            var targetBlockB = new BufferBlock<int>(options);

            sourceBlock.LinkTo(targetBlockA);
            sourceBlock.LinkTo(targetBlockB);
        }
    }
}
#endregion