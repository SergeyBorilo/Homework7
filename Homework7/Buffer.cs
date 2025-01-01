namespace Homework7;

public class Buffer<T>
{
    private readonly Queue<T> _queue = new Queue<T>();
    private readonly int _capacity;
    private readonly object _locker = new object();

    public Buffer(int capacity)
    {
        _capacity = capacity;
    }

    public void Add(T item)
    {
        lock (_locker)
        {
            while (_queue.Count >= _capacity) Monitor.Wait(_locker);
            _queue.Enqueue(item);
            Monitor.PulseAll(_locker);
        }
    }

    public T Remove()
    {
        lock (_locker)
        {
            while (_queue.Count == 0) Monitor.Wait(_locker);

            var itemToRemove = _queue.Dequeue();
            Monitor.PulseAll(_locker);
            return itemToRemove;
        }

    }
}
