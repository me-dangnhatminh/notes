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
            PropagatingErrors.Run();
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
