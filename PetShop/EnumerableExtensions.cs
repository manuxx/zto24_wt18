using System.Collections.Generic;

namespace Training.DomainClasses
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IItem> OneAtATime<IItem>(IEnumerable<IItem> items)
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }
    }
}