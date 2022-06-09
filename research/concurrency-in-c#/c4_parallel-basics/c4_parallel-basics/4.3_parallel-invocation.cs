using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c4_parallel_basics
{
    /* Parallel Invocation
    * Problem:
    * Solution:
    */
    internal class ParallelInvocation
    {
        public static void ProcessArray(double[] array)
        {
            int length = array.Length;
            Parallel.Invoke(
                () => ProcessPartialArray(array, 0, 3),
                () => ProcessPartialArray(array, 3, length)
                );
        }

        public static void ProcessPartialArray(double[] array, int begin, int end)
        {
            Parallel.For(begin, end, (index, state) =>
            {
                double value = array[index];
                Console.WriteLine($"{begin}-{end}: {value}");
            });
        }

        static void DoAction20Times(Action action)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray(); // Tao ra 20 lần action

            Parallel.Invoke(actions); // Có thể truyền một mảng các action
        }

        //Parallel.Invoke hỗ trợ Cancellation giống như các thành viên khác của lớp parallel
        static void DoAction20Times(Action action, CancellationToken token)
        {
            Action[] actions = Enumerable.Repeat(action, 20).ToArray(); // Tao ra 20 lần action
            Parallel.Invoke(new ParallelOptions { CancellationToken = token }, actions);
        }

        public static async Task Run()
        {
            ProcessArray(new double[5] { 1, 3, 5, 6, 7 });


        }
    }
}
