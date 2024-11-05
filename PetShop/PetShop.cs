using System;
using System.Collections.Generic;
using System.Linq;
using Training.DomainClasses;

namespace PetShop
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
            result.Sort((pet1, pet2) => string.Compare(pet1.name, pet2.name, StringComparison.Ordinal));
            return result;
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.AllWhere(PetVerifier.OfSpecie(Species.Cat));
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllWhere(PetVerifier.OfSpecie(Species.Mouse));
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllWhere(PetVerifier.OfSex(Sex.Female));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllWhere(pet => pet.species == Species.Dog && pet.yearOfBirth > 2010);
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllWhere(pet1 => pet1.sex == Sex.Male && pet1.species == Species.Dog);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllWhere(pet1 => pet1.yearOfBirth > 2011 || pet1.species == Species.Rabbit);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllWhere(PetVerifier.BornAfterYear(2010));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return AllPets().Except(AllMice());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllWhere(pet => pet.species == Species.Dog || pet.species == Species.Cat);
        }
    }
}