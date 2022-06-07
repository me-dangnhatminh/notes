using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /* Reporting Progress
     * Problem
     *  Ta cần phản hồi tiến trình trong khi một hoạt động đang thực thi.
     * Solution
     *  Sử dụng IProgress<T> và Progress<T>
     */
    public class ReportingPregress
    {
        public static async Task MyMethodAsync(IProgress<double> progress = null)
        {
            bool done = false;
            double percentComplete = 0;
            if (progress != null)
                while (!done)
                {
                    progress.Report(percentComplete);
                    // Mô phỏng tiến trình 0->100%
                    await Task.Delay(TimeSpan.FromMilliseconds(100));
                    if (percentComplete >= 100) done = true;
                    percentComplete += 1;
                }
        }

        public static async Task CallMyMethodAsync()
        {
            Progress<double> progress = new Progress<double>();
            progress.ProgressChanged += (sender, args) =>
            {
                Console.Clear();
                Console.WriteLine("Perscent {0}%", args);
            };
            await MyMethodAsync(progress);
        }

        public static async Task Run()
        {
            //await CallMyMethodAsync();
        }
    }
}
