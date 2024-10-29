using System.Collections;
using System.Collections.Generic;

namespace PetShop;

public class ReadOnlySet<T>(IList<T> petsInTheStore) : IEnumerable<T>
{
    public IEnumerator<T> GetEnumerator()
    {
        return petsInTheStore.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}