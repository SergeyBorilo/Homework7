namespace Homework7;

class Program
{
    static void Main(string[] args)
    {
        var buffer = new Buffer<int>(10);
        var producer = new Producer(buffer);
        var consumer = new Consumer(buffer);

        var producerThread = new Thread(producer.Produce);
        var consumerThread = new Thread(consumer.Consume);

        producerThread.Start();
        consumerThread.Start();

        producerThread.Join();
        consumerThread.Join();

        Console.WriteLine("Completion of work");
    }
}
