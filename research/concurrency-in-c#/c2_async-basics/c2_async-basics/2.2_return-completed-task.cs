using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /* 2.2 Return Completed Task
     * Problem:
     *  Đôi khi ta cần truyển khai một phương thức đồng bộ với một asynchronous signature
     * Solution
     *  Sử dụng Task.FromResult
     */
    public class ReturnCompletedTask
    {
        public interface IMyAsyncInterface
        {
            //static Task<int> GetValueAsync() => throw new NotImplementedException();
            //static Task<T> NotImplementedAsync<T>() => throw new NotImplementedException();
            //static Task<int> GetValueAsync(CancellationToken cancellationToken) => throw new NotImplementedException();
        }

        public class MySynchronousImplementation : IMyAsyncInterface
        {
            /**
             * - Đối với các phương thức không có giá trị trả về ta CÓ THỂ sử dụng Task.CompletedTask (thay vì Task.FromResult)
             * đó là một Task được lưu trong bộ nhớ cached đã được hoàn thành thành công.
             */
            public static Task<int> GetValueAsync()
            {
                return Task.FromResult(13);
            }

            /**
             * Task.FromResult chỉ cung cấp các nhiệm vụ đã hoàn thành với kết quả thành công. Nếu cần một task trả về exeption ta có thể dùng Task.FromExeption
             */
            public static Task<T> NotImplementedAsync<T>()
            {
                return Task.FromException<T>(new NotImplementedException());
            }

            /**
             * Task.FromCanceled để tạo các nhiệm vũ đã bị hủy bỏ từ một nhiệm vụ nhất định CancellationToken
             */
            public static Task<int> GetValueAsync(CancellationToken cancellationToken)
            {
                if (cancellationToken.IsCancellationRequested)
                    return Task.FromCanceled<int>(cancellationToken);
                return Task.FromResult(13);
            }


        }

        /* Discussion
         * - Nếu thường xuyên sử dùng Task.FromResult cùng với một giá trị thì nên xem xét lưu vào bộ nhớ đệm
         * để tránh tạo thêm các instance khiến garbage-collected phải thu dọn.
         * - Một cách hợp lý, Task.FromResult, Task.FromException và Task.FromCanceled là các helper methods and
         * shortcuts cho general-purpose TaskCompletionSource<T>
         */

        public static async Task Run()
        {
            //int result = await MySynchronousImplementation.GetValueAsync();
            //Console.WriteLine(result);
            //await MySynchronousImplementation.NotImplementedAsync<string>();
        }
    }
}
