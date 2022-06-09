using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4_parallel_basics
{
    /* Dynamic Parallelism
     * Problem: Bạn có một tình huống parallel phức tạp hơn trong đó cấu trúc và số lượng task parallel phụ thuộc vào thông tin chỉ được biết trong thời gian chạy
     * Solution:
     */
    class Node
    {
        public object Data { set; get; } = null;
        public Node Left { set; get; } = null;
        public Node Right { set; get; } = null;
    }

    internal class DynamicParallelism
    {
        public static void Traverse(Node current)
        {
            Console.WriteLine(current.Data);
            if (current.Left != null)
            {
                Task.Factory.StartNew(
                        () => Traverse(current.Left),
                        CancellationToken.None,
                        TaskCreationOptions.AttachedToParent,
                        TaskScheduler.Default
                    );
            }

            if (current.Right != null)
            {
                Task.Factory.StartNew(
                    () => Traverse(current.Right),
                    CancellationToken.None,
                    TaskCreationOptions.AttachedToParent,
                    TaskScheduler.Default);
            }
        }
        public static void ProcessTree(Node root)
        {
            Task task = Task.Factory.StartNew(
                () => Traverse(root),
                CancellationToken.None,
                TaskCreationOptions.None,
                /*  Tag AttachedToParent đảm bảo rằng Task cho mỗi branch được liên kết với Task cho node cha của nó.
                 *  Điều này sẽ tạo ra các mối quan hệ cha/con giữa các phiên bản của Task phản chiếu mối quan hệ cha con tron các node
                 *  Nhiệm vụ cha thực hiện ủy quyền của họ và sau đó đợi các task con hoàn thành, Các exception từ task con sau đó đươc truyền từ các task con sang task cha của chúng
                 *  Vì vậy, ProcessTree có thể đợi các task cho toàn bộ cây chỉ bằng cách gọi wait trên một task duy nhất của root
                 */
                TaskScheduler.Default);

            // Nếu không gặp tình huống cha/con, ta có thể lên lịch thực hiện bất kỳ nhiệm vụ nào bằng cách sử dụng continuation, đó làm một tác vụ riêng biệt sẽ thực hiện khi task ban đầu hoàn thành.
            task.ContinueWith(
                    t => Console.WriteLine("Task is done"),
                    CancellationToken.None,
                    TaskContinuationOptions.None, // Chú ý là --> TaskContinuationOptions <-- chứ không phải TaskCreationOptions
                    TaskScheduler.Default
                );
            // đối số "t" là phần tiếp theo giống như task

            task.Wait();
        }
        // WARNING: sử dụng task để xử lý parallel hoàn toàn khác với sử dụng task để xứ lý async
        /*  Taks phục vụ 2 múc đính trong concurrent programming: nó có thể là parallel hoặc task async
         *  
         *  Task Parallel (not parallel) block các member bằng Task Await, Task.Result, Task.WaitAll and Task.WaitAny và AttachedToParent để xử lý quan hệ
         *  Parallel Task được tạo bằng Task.Run() hoặc Task.Factory.StartNew.
         *  
         *  Ngược lại Các Task async nên tránh chặn các member và ưu tiên await, Task.WhenAll và Task.WhenAny
         */
        public static async Task Run()
        {
            Node node1 = new Node() { Data = 1 };
            Node node2 = new Node() { Data = 2 };
            Node node3 = new Node() { Data = 3 };

            Node node1_1 = new Node() { Data = 11, Left = node1 };
            Node node1_2 = new Node() { Data = 11, Left = node2, Right = node3 };

            Node root = new Node() { Data = "Root", Left = node1_1, Right = node1_2 };
            ProcessTree(root);
        }
    }
}
