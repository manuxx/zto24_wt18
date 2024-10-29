using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

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
            IList<Pet> catsInTheStore = new List<Pet>();

            foreach (var pet in _petsInTheStore)
            {
                if (pet.species.Equals(Species.Cat))
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var sortedPets = new List<Pet>(_petsInTheStore);
            sortedPets.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return sortedPets;
        }
    }
}