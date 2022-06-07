using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c2_async_basics
{
    /* Avoiding Context for Continuations
     * Problem
     *  
     */
    public class AvoidingContextforContinuations
    {
        async Task ResumeOnContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            // This method resumes within the same context.
        }

        async Task ResumeWithoutContextAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(1)).ConfigureAwait(false);

            // This method discards its context when it resumes.
        }

        public static async Task Run()
        {

        }
    }
}
