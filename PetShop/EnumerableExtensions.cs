using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace Training.DomainClasses
{
    internal class EnumerableExtensions
    {
        public static IEnumerable<TItem> OneAtTheTime<TItem>(IEnumerable<TItem> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }

    }
}
