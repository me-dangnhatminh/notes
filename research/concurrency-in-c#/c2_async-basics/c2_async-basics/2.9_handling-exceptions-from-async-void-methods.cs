using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace c2_async_basics
{
    /* Handling Exceptions from async void Methods
     * Problem:
     *  Đôi lúc cần xử lý các exception từ hàm void
     * Solution:
     *  Không có giải pháp tốt, nếu trường hợp không đó bắt buộc thì hãy dùng Task
     */
    public class HandlingExceptionsfromasyncvoidMethods
    {
        sealed class MyAsyncCommand : ICommand
        {
            public event EventHandler? CanExecuteChanged;

            async void ICommand.Execute(object? parameter)
            {
                await Execute(parameter);
            }

            public async Task Execute(object? parameter)
            {
                throw new NotImplementedException();
            }

            public bool CanExecute(object? parameter)
            {
                throw new NotImplementedException();
            }
        }

        // BAD CODE!!!
        // In the real world, do not use async void unless you have to.
        // Nếu không dùng thư viện để xử lý ex thì phải thêm try-catch ở đây, them try-catch ở môi trường gọi không xử lý được
        public static async void ThrowNotImplementedExceptionAsync()
        {
            throw new NotImplementedException();
        }

        // Có thể dùng thư viện Nito.AsyncEx để xử lý
        public static async Task Run()
        {
            //MyAsyncCommand myAsyncCommand = new MyAsyncCommand();
            //await myAsyncCommand.Execute(new { });
            try
            {
                AsyncContext.Run(() => ThrowNotImplementedExceptionAsync());
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex);
            }
        }
    }
}
