namespace Homework7;

public class Producer
{
    private readonly Buffer<int> _buffer;

    public Producer(Buffer<int> buffer)
    {
        _buffer = buffer;
    }

    public void Produce()
    {
        for (var i = 0; i < 10; i++)
        {
            try
            {
                var value = new Random().Next(100);
                _buffer.Add(value);
                Log($"Produced {value}");
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
