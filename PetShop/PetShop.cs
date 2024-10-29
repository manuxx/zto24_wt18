using System;
using System.Collections;
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
            return new ReadOnlySet(this._petsInTheStore);
        }

        public void Add(Pet newPet)
        {

                if (!_petsInTheStore.Contains(newPet))
                {
                    _petsInTheStore.Add(newPet);
                }
        }
    }

    public class ReadOnlySet : IEnumerable<Pet>
    {
        private readonly IEnumerable<Pet> _pets;

        public ReadOnlySet(IEnumerable<Pet> pets)
        {
            this._pets = pets;
        }
        public IEnumerator<Pet> GetEnumerator()
        {
            return this._pets.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}