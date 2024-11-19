using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Where<TItem>
    {

        public static PreCriterium<TItem, TProperty> HasAn<TProperty>(Func<TItem, TProperty> propertySelector)
        {
            return new PreCriterium<TItem, TProperty>(propertySelector);
        }
    }

    public class PreCriterium<TItem, TProperty>
    {
        private readonly Func<TItem, TProperty> _propertySelector;

        public PreCriterium(Func<TItem, TProperty> propertySelector)
        {
            _propertySelector = propertySelector;
        }

        public Criteria<TItem> EqualTo(TProperty value)
        {
            return new AnonymousCriteria<TItem>((TItem item) => _propertySelector(item).Equals(value));
        }
    }
}
