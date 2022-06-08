using System;

namespace c3_asynchronous_streams
{
    /** Asynchronous Stream
    * Các luồng không đồng bộ là một cách để nhận nhiều mục dữ liệu (data items) một cách không đồng bộ,
    * chúng được xây dựng dựa trên asynchronous enumerable(IAsyncEnumerable<T>).
    * Một kiểu async-enumerable là một version của enumerable, điều này có nghĩa là nó có thể sản xuất các mặt hàng theo yêu cầu cho người tiêu dùng
    * và mỗi mặt hằng có thể được sản xuất không đồng bộ.
    ** Asynchronous stream and Task
    * Asynchronous stream giống với kiểu enumerable. Cụ thể, một IAsyncEnumerator<T> có thể cung cấp bất kỳ số lượng T giá trị nào tại một thời điểm.
    ** Asynchronous stream and IEnumerable<T>
    ** Asynchronous stream and IObservable<T>
    */
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            //CreatingAsynchronousStreams.Run();
            //ConsumingAsynchronousStreams.Run();
            //UsingLINQwithAsynchronousStreams.Run();
            AsynchronousStreamsandCancellation.Run();
            Console.ReadKey();
        }
    }
}
