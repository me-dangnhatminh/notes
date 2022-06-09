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
            LinkingBlocks.Run();
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
