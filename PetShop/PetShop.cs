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
            foreach (Pet p in this._petsInTheStore)
            {
                if (p.species == Species.Cat) yield return p;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {   
            List<Pet> tmp = new List<Pet>(_petsInTheStore);
            tmp.Sort((pet, pet1) => pet.name.CompareTo(pet1.name) );
            return tmp.OneAtATIme();
        }
    }
}