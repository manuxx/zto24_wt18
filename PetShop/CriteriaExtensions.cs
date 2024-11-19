using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.DomainClasses;

namespace PetShop
{
    public static class CriteriaExtensions
    {
        public static Criteria<TItem> And<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            return new Conjunction<TItem>(criteria1, criteria2);
        }

        public static Criteria<TItem> Or<TItem>(this Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            return new Alternative<TItem>(criteria1, criteria2);
        }
    }
}
