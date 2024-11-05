using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllCats()
        {
            return AllOfType(Species.Cat);
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllOfType(Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllOfSex(AllPets(), Sex.Female);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return BornAfterYear(AllOfType(Species.Dog), 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllOfSex(AllOfType(Species.Dog), Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return BornAfterYear(AllPets(), 2011).Concat(AllOfType(Species.Rabbit)).Distinct();
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return BornAfterYear(AllPets(), 2010);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllPets().Except(AllMice());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllCats().Concat(AllOfType(Species.Dog));
        }

        private IEnumerable<Pet> AllOfType(Species species)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.species == species)
                    yield return pet;
            }
        }

        private IEnumerable<Pet> BornAfterYear(IEnumerable<Pet> pets, int year)
        {
            foreach (var pet in pets)
            {
                if (pet.yearOfBirth > year)
                    yield return pet;
            }
        }

        private IEnumerable<Pet> AllOfSex(IEnumerable<Pet> pets, Sex sex)
        {
            foreach (var pet in pets)
            {
                if (pet.sex == sex)
                    yield return pet;
            }
        }
    }
}