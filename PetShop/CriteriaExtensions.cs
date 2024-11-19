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
        public static Conjunction<TItem> And<TItem>(this Criteria<TItem> first, Criteria<TItem> second)
        {
            return new Conjunction<TItem>(first, second);
        }
        public static Alternative<Pet> Or(this Criteria<Pet> first, Criteria<Pet> second)
        {
            return new Alternative<Pet>(first, second);
        }
    }
}
