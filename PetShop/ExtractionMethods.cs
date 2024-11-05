using System;
using System.Collections.Generic;
using Training.DomainClasses;

namespace Training.DomainClasses
{
    public static class ExtractionMethods
    {
        public static IEnumerable<Pet> PetsEnumerable(IList<Pet> petsInTheStore, Predicate<Pet> condition)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }

        public static IEnumerable<Pet> GenericEnumerable(IList<Pet> petsInTheStore, Predicate<Pet> condition)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }
    }
}