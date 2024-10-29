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
            return new ReadOnlySet(_petsInTheStore);
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
        public ReadOnlySet(IEnumerable<Pet> pets)
        {
            _pets = pets;
        }

        private IEnumerable<Pet> _pets;

        public IEnumerator<Pet> GetEnumerator()
        {

            foreach (var pet in _pets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}