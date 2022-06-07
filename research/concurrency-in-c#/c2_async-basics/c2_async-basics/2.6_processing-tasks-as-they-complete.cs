using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /*Processing Tasks as They Complete
     * Problem
     *  Ta có một danh sách các task, muốn xử lý cho từng cái nhưng k phải đợi bất kỳ task nào khắc
     * Solution
     */
    public class ProcessingTasksasTheyComplete
    {
        public static async Task<int> DelayAndReturnAsync(int value)
        {
            await Task.Delay(TimeSpan.FromSeconds(value));
            return value;
        }

        public static async Task AwaitAndProcessAsync(Task<int> task)
        {
            int result = await task;
            Console.WriteLine(result);
        }

        public static async Task ProcessTasksAsync()
        {
            Task<int> taskA = DelayAndReturnAsync(1);
            Task<int> taskB = DelayAndReturnAsync(2);
            Task<int> taskC = DelayAndReturnAsync(3);
            Task<int>[] tasks = new[] { taskA, taskB, taskC };

            IEnumerable<Task> taskQuery = from t in tasks select AwaitAndProcessAsync(t);
            Task[] processingTask = taskQuery.ToArray();

            // Dong 35,36 tương đương với
            Task[] processingTasks = tasks.Select(async t =>
            {
                int result = await t;
                Console.WriteLine(result);
            }).ToArray();

            await Task.WhenAll(processingTask);
        }

        /* Recoment AsyncEx library, in the Nito.AsyncEx NuGet package.
         */
        public static async Task Run()
        {
            await ProcessTasksAsync();
        }
    }
}
