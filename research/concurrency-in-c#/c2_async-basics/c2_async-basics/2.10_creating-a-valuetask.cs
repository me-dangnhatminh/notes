using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    public class CreatingaValueTask
    {
        public static async ValueTask<int> RundomIntAsync()
        {
            Random random = new Random();

            await Task.Delay(2000); // 100 milis
            return random.Next(0, 100);
        }

        public static async Task AwaitAndProcessRundomIntAsync()
        {
            int intRandomed = await RundomIntAsync();
            Console.WriteLine(intRandomed);
        }

        /**
         * Trong một số trường hợp valuetask có thể trả về một giá trị ngay lập tức, trong trường hợp đó
         * ta có thể tối ưu hóa cho trường hợp đó bằng cách sử dụng phương thức ValueTask<T> constructor,
         * sau đó chuyển đến method async khi cần thiết
         */
        public static async Task<int> SlowMethodAsync()
        {
            await Task.Delay(1000); // asynchronous work.
            return 13;
        }

        public static ValueTask<int> MethodAsync(bool canBehaveSynchronously)
        {
            if (canBehaveSynchronously) return new ValueTask<int>(12);
            return new ValueTask<int>(SlowMethodAsync());
        }

        private static Func<Task> _disposeLogic;
        public static ValueTask DisposeLogic()
        {
            if (_disposeLogic == null) return default;

            // Note: this simple example is not threadsafe;
            //  if multiple threads call DisposeAsync,
            //  the logic could run more than once.
            Func<Task> logic = _disposeLogic;
            _disposeLogic = null;
            return new ValueTask(logic());
        }

        public static async Task Run()
        {
            //AwaitAndProcessRundomIntAsync();
            //int result = await MethodAsync(true);
            //Console.WriteLine(result);

            //Hạn chế của valuetask là nó chỉ có thể await một lần duy nhất(lý thuyết là vậy, còn thực hành thì chả hiểu sao vẫn được)
            ValueTask<int> valueTask1 = RundomIntAsync();

            int value1 = await valueTask1;
            int value2 = await valueTask1;
            Console.WriteLine("ValueTask: " + value1 + " - " + value2);

            //Convert ValueTask into Task
            Task<int> task1 = RundomIntAsync().AsTask();
            int valueTest = await RundomIntAsync().AsTask(); // Sách bảo không thể vừa gọi astask vừa gọi await nhưng thực hành lại được, quỳ lạy với sách luôn

            int value3 = await task1;
            int value4 = await task1;
            Console.WriteLine("ValueTask: " + value3 + " - " + value4);
        }
    }
}
