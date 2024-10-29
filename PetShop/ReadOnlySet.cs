using System.Collections;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItems> : IEnumerable<TItems>
    {
        private readonly IList<TItems> _items;

        public ReadOnlySet(IList<TItems> items)
        {
            _items = items;
        }

        public IEnumerator<TItems> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}