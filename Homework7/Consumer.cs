
namespace Homework7;

public class Consumer
{
    private readonly Buffer<int> _buffer;

    public Consumer(Buffer<int> buffer)
    {
        _buffer = buffer;
    }

    public void Consume()
    {
        for (var i = 0; i < 10; i++)
        {
            try
            {
                var value = _buffer.Remove();
                Log($"Consumer: {value}");
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }

    private void Log(string s)
    {
        File.AppendAllText("log.txt", $"{DateTime.Now}: {s}");
    }
}
