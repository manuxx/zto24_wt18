using System;
using System.Collections.Generic;
using System.Collections.Immutable;
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
            foreach (var pet in _petsInTheStore)
            {
                yield return pet;
            }
        }

        public void Add(Pet newPet)
        {
            foreach (var p in this._petsInTheStore)
                if (p.name == newPet.name)
                    return;


            this._petsInTheStore.Add(newPet);
        }
    }
}