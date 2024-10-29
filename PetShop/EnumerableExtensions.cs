using System;
using System.Collections.Generic;
using System.Text;
using Training.DomainClasses;

namespace PetShop
{
    internal class EnumerableExtensions
    {
        public static IEnumerable<Pet> OneAtTheTime(IEnumerable<Pet> pets)
        {
            foreach (var pet in pets)
            {
                yield return pet;
            }
        }

    }
}
