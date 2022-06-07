using System.Threading.Tasks;
using c2_async_basics;

namespace C2AsyncBasics
{
    public class Program
    {
        public static async Task Main()
        {
            // await PausingforaPeriodofTime.Run();
            // await ReturnCompletedTask.Run();
            // await ReportingPregress.Run();
            // await WaitingforaSetofTaskstoComplete.Run();
            // await WaitingforAnyTasktoComplete.Run();
            // await ProcessingTasksasTheyComplete.Run();
            await AvoidingContextforContinuations.Run();
        }
    }
}