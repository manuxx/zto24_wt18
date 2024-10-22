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
            return _petsInTheStore;
        }

        public void Add(Pet newPet)
        {
            if (IsPetUnique(newPet))
            {
                _petsInTheStore.Add(newPet);
            }
        }

        private bool IsPetUnique(Pet newPet)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (pet.Equals(newPet) || pet.name.Equals(newPet.name))
                {
                    return false;
                }
            }
            return true;
        }
    }
}