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
            UnlinkingBlocks.Run();
            Console.ReadKey();
        }
    }
}

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