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
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            throw new NotImplementedException();
        }
    }
}