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
            return AllPetsWhere(p => p.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllPetsWhere(p => p.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllPetsWhere(p => p.species == Species.Cat || p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllPetsWhere(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllPetsWhere(p => p.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllPetsWhere(p => p.yearOfBirth > 2010 && p.species == Species.Dog);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllPetsWhere(p => p.species == Species.Dog && p.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllPetsWhere(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllPetsWhere(Predicate<Pet> predicate)
        {
            return EnumerableExtensions.Filtered(this._petsInTheStore, predicate);
        }
    }
}