using System.Collections;

namespace Garage.Models;

internal class Garage<T> : IEnumerable<T> where T : Vehicle
{






    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
