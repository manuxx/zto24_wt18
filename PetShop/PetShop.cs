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

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return EnumerableExtensions.AllPetsWhere(pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011, _petsInTheStore);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return EnumerableExtensions.AllPetsWhere(pet => pet.species == Species.Cat || pet.species == Species.Dog, _petsInTheStore);
        }

        public IEnumerable<Pet> AllMice()
        {
            return EnumerableExtensions.AllPetsWhere(IsASpeciesOf(Species.Mouse), _petsInTheStore);
        }

        private static Predicate<Pet> IsASpeciesOf(Species species)
        {
            return pet => pet.species == species;
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return EnumerableExtensions.AllPetsWhere(IsAFemale(), _petsInTheStore);
        }

        private static Predicate<Pet> IsAFemale()
        {
            return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return EnumerableExtensions.AllPetsWhere(pet => pet.species != Species.Mouse, _petsInTheStore);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return EnumerableExtensions.AllPetsWhere(IsBornAfter(2010), _petsInTheStore);
        }

        private static Predicate<Pet> IsBornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }



        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return EnumerableExtensions.AllPetsWhere(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010, _petsInTheStore);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return EnumerableExtensions.AllPetsWhere(pet => pet.species == Species.Dog && pet.sex == Sex.Male, _petsInTheStore);
        }
    }
}