using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<IEquatable<TItem>> _petsInTheStore;

        public PetShop(IList<IEquatable<TItem>> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<IEquatable<TItem>> AllPets()
        {
            return new ReadOnlySet<IEquatable<TItem>>(_petsInTheStore);
        }

        public void Add(IEquatable<TItem> newItem)
        {

                if (!_petsInTheStore.Contains(newItem))
                {
                    _petsInTheStore.Add(newItem);
                }
        }

        public IEnumerable<IEquatable<TItem>> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<IEquatable<TItem>> AllPetsSortedByName()
        {
            var result = new List<IEquatable<TItem>>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }


        public IEnumerable<IEquatable<TItem>> AllMice()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, IsSpeciesOf(Species.Mouse));
        }

        private static Predicate<IEquatable<TItem>> IsSpeciesOf(Species species)
        {
            return pet => pet.species == species;
        }

        public IEnumerable<IEquatable<TItem>> AllFemalePets()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, IsFemale());
        }

        private static Predicate<IEquatable<TItem>> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<IEquatable<TItem>> AllCatsOrDogs()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<IEquatable<TItem>> AllPetsButNotMice()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, pet => pet.species != Species.Mouse);
        }

        public IEnumerable<IEquatable<TItem>> AllPetsBornAfter2010()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, IsBornAfter(2010));
        }

        private static Predicate<IEquatable<TItem>> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<IEquatable<TItem>> AllDogsBornAfter2010()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<IEquatable<TItem>> AllMaleDogs()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }

        public IEnumerable<IEquatable<TItem>> AllPetsBornAfter2011OrRabbits()
        {
            return EnumerableExtensions.AllItemsThat(_petsInTheStore, pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011);
        }
    }
}