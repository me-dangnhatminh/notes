using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4_parallel_basics
{
    /*
     * Discussion
     *  Parallel.ForEach cho cho phép sử lý song song trên một chuỗi giá trị. Một phương pháp tương tự là LINQ Parallel(PLINQ),
     *  cung cấp nhiều khả năng tương tự. Một điểm khác duy nhất là, PLINQ bảo rằng nó có thể sử dụng tất cả các lõi trên máy tính,
     *  trong khi parallel sẽ phản ứng động với các điều kiện thay đổi của CPU.
     */
    public class Matrix
    {
        public void Rotate(float degrees)
        {
            Console.WriteLine(degrees);
        }
    }
    internal class ParallelProcessingofData
    {
        static async Task RotateMatrices(IEnumerable<Matrix> matrices, float degrees)
        {
            Console.WriteLine("start");
            Parallel.ForEach(matrices, (matrix, state) =>
            {

                state.Stop(); //Khi gọi stop nó sẽ không gọi những thread chưa được gọi, nghĩa là sẽ có nhưng thread đã được gọi, bao gôm cả cái hiện tại sẽ vẫn tiếp tục chạy
                matrix.Rotate(123);
            });
            Console.WriteLine("end");
        }

        static async Task RotateMatrices(IEnumerable<Matrix> matrices, float degrees, CancellationToken cancellationToken)
        {
            Parallel.ForEach(matrices, new ParallelOptions { CancellationToken = cancellationToken }, matrix =>
            {
                matrix.Rotate(degrees);
            });
        }

        // Note: Đây không phải là cách triển khai hiệu quả
        static void ShowNumberParallel( IEnumerable<int> numbers)
        {
            object mutex = new object();
            int i = 0;
            Parallel.ForEach(numbers, ( num, state ) =>
            {
                lock(mutex)
                {
                    Console.WriteLine($"[{i}]: " + num);
                    i++;
                }
            });
        }
        public static async Task Run()
        {
            //IEnumerable<Matrix> matrices = new List<Matrix>()
            //{
            //    new Matrix(),
            //    new Matrix(),
            //    new Matrix(),
            //    new Matrix(),
            //};
            //RotateMatrices(matrices, 12);

            IEnumerable<int> nums = new List<int>() { 1,2,3,4,5,6,7,8,9,10 };
            ShowNumberParallel(nums);
        }
    }
}
