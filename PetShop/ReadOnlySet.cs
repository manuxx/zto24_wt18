using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Training.DomainClasses
{
    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        private readonly IEnumerable<TItem> _items;

        public ReadOnlySet(IEnumerable<TItem> items)
        {
            this._items = items;
        }

        public IEnumerator<TItem> GetEnumerator()
        {
            return this._items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
