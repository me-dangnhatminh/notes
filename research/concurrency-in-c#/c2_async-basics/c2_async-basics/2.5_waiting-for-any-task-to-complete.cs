using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /* Task.WhenAny
     * Trả về cái đầu tiên hoàn thành
     * Discussion
     *  Task do Task.WhenAny trả về không bao giờ hoàn thành với trạng thái lỗi hoặc bị hủy.
     *  Nếu Task inner-task (task bên trong whenany) hoàn thành với một ngoại lệ thì ngoại lệ ấy không được truyền đến outer-task (task bên ngoài).
     *  
     */
    public class WaitingforAnyTasktoComplete
    {
        // Returns the length of data at the first URL to respond.
        public static async Task<int> FirstRespondingUrlAsync(HttpClient client, string urlA, string urlB)
        {
            // Start both downloads concurrently.
            Task<byte[]> downloadTaskA = client.GetByteArrayAsync(urlA);
            Task<byte[]> downloadTaskB = client.GetByteArrayAsync(urlB);

            // Wait for either of the tasks to complete.
            Task<byte[]> completedTask =
                await Task.WhenAny(downloadTaskA, downloadTaskB);

            // Return the length of the data retrieved from that URL.
            byte[] data = await completedTask;
            return data.Length;
        }

        public static async Task Run()
        {
            using HttpClient client = new HttpClient();
            await FirstRespondingUrlAsync(client, "", "");
        }
    }
}
