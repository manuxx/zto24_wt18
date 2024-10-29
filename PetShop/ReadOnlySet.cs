using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<IItem> : IEnumerable<IItem>
    {
        private readonly IEnumerable<IItem> _items;

        public ReadOnlySet(IEnumerable<IItem> items)
        {
            _items = items;
        }

        public IEnumerator<IItem> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}