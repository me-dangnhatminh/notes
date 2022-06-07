using System.Threading.Tasks;

namespace C2AsyncBasics
{
    public class Program
    {
        // Giả mạo không đồng bộ
        public static async Task<T> DelayResult<T>(T result, TimeSpan delay)
        {
            await Task.Delay(delay);
            return result;
        }

        /* Exponential backoff
         * Là một chiến lược trong đó ta tăng độ trẽ giữa các lần thử lại,
         * Sử dụng trong các dịch vụ web để đảm bảo máy chủ không bị ngập trong các lần thử lại
         */
        public static async Task<string> DownloadStringWithRetries(HttpClient client, string uri)
        {
            // Retry after 1 second, then after 2 seconds, then 4.
            TimeSpan nextDelay = TimeSpan.FromSeconds(1);
            for (int i = 0; i <= 3; i++)
            {
                try
                {
                    return await client.GetStringAsync(uri);
                }
                catch
                {
                    System.Console.WriteLine($"Connect to {uri} failed  {i}nd time");
                }
                await Task.Delay(nextDelay);
                nextDelay += nextDelay;
            }
            // Try one last time, allowing the error to propagate.
            return await client.GetStringAsync(uri);
        }

        /* Soft Timeout
         * Hủy tác vụ sau một thời gian cụ thể
         * Mã này sẽ trả về null nếu dịch vụ không phản hồi trong 3s
         * Hạn chế của phương pháp này là nếu hoạt động hết thời gian, nó không bị hủy
         */
        public static async Task<string> DownloadStringWithTimeout(HttpClient client, string uri)
        {
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            Task<string> downloadTask = client.GetStringAsync(uri);
            Task timeoutTask = Task.Delay(Timeout.InfiniteTimeSpan, cts.Token);

            // Trả về nếu một trong 2 task hoàn thành
            Task completedTask = await Task.WhenAny(downloadTask, timeoutTask);
            if (completedTask == timeoutTask) return null;  // Nếu task completed là timeout thì trả về null vì đã vượt quá thời gian
            return await downloadTask;
        }

        public static async Task Main()
        {
            using var httpClient = new HttpClient();
            // -----------
            // string message = await DelayResult<string>("Called before delay", TimeSpan.FromSeconds(1));
            // -----------
            //string result = await DownloadStringWithRetries(httpClient, "https://www.facebook123.com");
            //Console.WriteLine(result);
            // -----------
            string result = await DownloadStringWithTimeout(httpClient, "https://www.facebook123.com");
        }
    }
}