using System.Collections;

namespace Garage.Models;

public class Garage<T> : IEnumerable<T> where T : Vehicle
{
    private int Capacity { get; set; }
    private List<T> vehicles = new List<T>();

    public Garage(int capacity)
    {
        Capacity = capacity;
    }
    public void Add(T item)
    {
        if (vehicles.Count >= Capacity)
            throw new InvalidOperationException("Garage is full.");
        vehicles.Add(item);
    }

    public IEnumerator<T> GetEnumerator()
    {
        return vehicles.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Remove(T item)
    {
        vehicles.Remove(item);
    }
}
