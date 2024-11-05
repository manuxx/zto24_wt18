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
            return AllOfType(_petsInTheStore, pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllMice()
        {
            return AllOfType(_petsInTheStore, pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return AllOfType(AllPets(), pet => pet.sex == Sex.Female);
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return AllOfType(AllOfType(_petsInTheStore, pet => pet.species == Species.Dog), pet1 => pet1.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return AllOfType(AllOfType(_petsInTheStore, pet => pet.species == Species.Dog), pet1 => pet1.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return AllOfType(AllPets(), pet1 => pet1.yearOfBirth > 2011)
                .Concat(AllOfType(_petsInTheStore, pet => pet.species == Species.Rabbit))
                .Distinct();
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return AllOfType(AllPets(), pet => pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllPets().Except(AllMice());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return AllCats().Concat(AllOfType(_petsInTheStore, pet => pet.species == Species.Dog));
        }

        private IEnumerable<Pet> AllOfType(IEnumerable<Pet> petsInTheStore, Func<Pet, bool> condition)
        {
            foreach (var pet in petsInTheStore)
            {
                if (condition(pet))
                    yield return pet;
            }
        }
    }
}