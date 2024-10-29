using System;
using System.Collections;
using System.Collections.Generic;

namespace PetShop;

public class NameComparer : IComparer<Pet>
{
    public int Compare(Pet x, Pet y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (y is null) return 1;
        if (x is null) return -1;
        var nameComparison = string.Compare(x.name, y.name, StringComparison.Ordinal);
        return nameComparison;
    }
}