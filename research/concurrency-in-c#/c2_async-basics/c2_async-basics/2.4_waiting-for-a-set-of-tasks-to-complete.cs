using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /*Waiting for a Set of Tasks to Complete
     * Problem
     */
    public class WaitingforaSetofTaskstoComplete
    {
        public static async Task<string[]> DownloadAllAsync(HttpClient client, IEnumerable<string> urls)
        {
            // Define the action to do for each URL.
            var downloads = urls.Select(url => client.GetStringAsync(url));
            // Chưa có action nào thực sự bắt đầu bởi vì sequence chưa được evaluated.

            // Bắt đầu tải xuống tất các url đồng thời.
            Task<string>[] downloadTasks = downloads.ToArray();
            // Bây giờ các action mới thật sự bắt đầu.

            // Chờ đợi tất cả tải xuống hết mới xử lí tiếp
            string[] htmlPages = await Task.WhenAll(downloadTasks);

            Console.WriteLine(string.Concat(htmlPages));

            return htmlPages;
        }
        /* Discussion
         * Nếu có bất kỳ task nào ném ngoại lệ, thì Task.WhenAll() sẽ trả về ngoại lệ duy nhất đó
         * Nếu có nhiều task ném cùng một ngoại lệ thì tất cả ngoại lệ đó sẽ được đặt trên Task trả về bởi Task.WhenAll.
         * Nếu cần xử lý từng ngoại lệ cụ thể có thể kiểm tra thuộc tính Exception trên Task
         */

        public static async Task ThrowNotImplementedExceptionAsync() => throw new NotImplementedException();
        public static async Task ThrowInvalidOperationExceptionAsync() => throw new InvalidOperationException();
        public static async Task ObserveOneExceptionAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();
            try
            {
                await Task.WhenAll(task1, task2);
            }
            catch (Exception ex)
            {
                // "ex" is either NotImplementedException or InvalidOperationException.
                if (ex.GetType().Name == "NotImplementedException")
                {
                    Console.WriteLine(ex.Message);
                }
                if (ex.GetType().Name == "InvalidOperationException")
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static async Task ObserveAllExceptionsAsync()
        {
            var task1 = ThrowNotImplementedExceptionAsync();
            var task2 = ThrowInvalidOperationExceptionAsync();

            // Nếu không dùng await để chờ nó sẽ chưa ném lỗi
            Task allTasks = Task.WhenAll(task1, task2);
            try
            {
                await allTasks;
            }
            catch
            {
                AggregateException allException = allTasks.Exception;
            }
        }
        public static async Task Run()
        {
            Task<int> task1 = Task.FromResult(3);
            Task<int> task2 = Task.FromResult(5);
            Task<int> task3 = Task.FromResult(7);

            int[] results = await Task.WhenAll(task1, task2, task3);
            // "results" contains { 3, 5, 7 }
            await ObserveAllExceptionsAsync();


        }
    }
}
