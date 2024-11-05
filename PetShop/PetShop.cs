using System;
using System.Collections.Generic;

namespace Training.DomainClasses
{
    public class PetShop
    {
        private IList<Pet> _petsInTheStore;

        public PetShop(IList<Pet> petsInTheStore)
        {
            this._petsInTheStore = petsInTheStore;
        }

        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public void Add(Pet newPet)
        {

                if (!_petsInTheStore.Contains(newPet))
                {
                    _petsInTheStore.Add(newPet);
                }
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, IsASpecies(Species.Mouse));
        }

        private static Predicate<Pet> IsASpecies(Species species)
        {
            return pet => pet.species == species;
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, IsFemale());
        }

        private static Predicate<Pet> IsFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        private static Predicate<Pet> IsMale()
        {
            return pet => pet.sex == Sex.Male;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, pet => pet.species == Species.Cat || pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, pet => pet.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, IsBornAfter(2010));
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, pet => pet.sex == Sex.Male && pet.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return EnumerableExtensions.ItemsEnumerable(_petsInTheStore, pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }
}