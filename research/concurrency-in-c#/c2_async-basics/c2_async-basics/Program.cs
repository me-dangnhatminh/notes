using System.Threading.Tasks;
async Task<T> DelayResult<T>(T result, TimeSpan delay)
{
    await Task.Delay(delay);
    return result;
}

Console.WriteLine("Start");
string message = await DelayResult<string>("Called before delay", TimeSpan.FromSeconds(1000));
Console.WriteLine(message);