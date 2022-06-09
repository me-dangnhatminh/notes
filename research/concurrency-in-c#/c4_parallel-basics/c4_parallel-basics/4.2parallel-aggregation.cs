using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4_parallel_basics
{
    /* Parallel Aggregation
     * Problem: Khi kết thúc một hoạt động song song, ta cần phải tổng hợp các kết quả. Vd về tổng hợp là tính tổng các giá trị hoặc tìm giá trị trung bình của chúng.
     * Solution: 
     */
    internal class ParallelAggregation
    {
        static int ParallelSum(IEnumerable<int> values)
        {
            object mutex = new object();
            int result = 0;
            Parallel.ForEach(source: values,
                localInit: () => 0,
                body: (item, state, localValue) => localValue + item,
                localFinally: localValue =>
                {
                    lock (mutex)
                        result += localValue;
                });
            return result;
        }

        //If use Parallel LINQ
        static int ParallelLinqSum(IEnumerable<int> values)
        {
            return values.AsParallel().Sum();
        }

        // Use aggregation
        static int ParalleLinqAggregateSum(IEnumerable<int> values)
        {
            return values.AsParallel().Aggregate( // hàm này tương tự reducer của js
                    seed: 0,
                    func: (sum, item) => { return sum + item; }
                );
        }

        public static async Task Run()
        {
            int result = ParallelSum(new List<int>() { 1, 2, 3 });
            Console.WriteLine(result);
        }
    }
}
