using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop
{
    public class Where<T>
    {

        public static PreCriterium<T, R> HasAn<T, R>(Func<T, R> propertySelector)
        {
            return new PreCriterium<T, R>(propertySelector);
        }
    }

    public class PreCriterium<T, R>
    {
        private readonly Func<T, R> _func;

        public PreCriterium(Func<T, R> func)
        {
            _func = func;
        }

        public Criteria<T> EqualTo(R eq)
        {
            return new AnonymousCriteria<T>((T item) => _func(item).Equals(eq));
        }
    }
}
