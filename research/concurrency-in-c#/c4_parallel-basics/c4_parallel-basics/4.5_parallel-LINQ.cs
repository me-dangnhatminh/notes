using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4_parallel_basics
{
    /* Parallel LINQ
     * Problem: Bạn cần thực hiện xử lý song song trên một chuỗi dữ liệu để tạo ra một chuỗi dữ liệu khác hoặc một summary của data
     * Solution:
     *  
     */
    internal class ParallelLINQ
    {
        // realworld scenarios sẽ tốn nhiều CPU-intensive hơn
        public static IEnumerable<int> MultiplyBy2(IEnumerable<int> values)
        {
            IEnumerable<int> result = values.AsParallel().Select(value =>
            {
                Console.WriteLine(value * 2);
                return value * 2;
            });

            result = values.AsParallel().AsOrdered().Select(v => v * 2); // AsOrdered sẽ giúp giữ nguyên thứ tự;

            return result;
        }

        public static int ParallelSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }

        public static void Run()
        {
            int[] number = new int[1000];
            for (int i = 0; i < 1000; i++)
            {
                number[i] = i;
            }

            IEnumerable<int> result = MultiplyBy2(number);
            int sum = ParallelSum(number);
            result.ToList().ForEach(v => Console.WriteLine(v));
        }
    }
}
