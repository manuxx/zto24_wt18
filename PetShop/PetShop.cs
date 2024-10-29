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

        public IEnumerable<Pet> AllCats()
        {
            var notFoundPets = new List<Pet>();
            foreach (var cat in _petsInTheStore)
            {
                if (cat.species == Species.Cat)
                {
                    notFoundPets.Add(cat); //yield return cat;
                }
            }

            return notFoundPets;
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);

            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }
    }
}