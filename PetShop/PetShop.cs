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

        public IEnumerable<Pet> AllPets() => new ReadOnlySet<Pet>(_petsInTheStore);

        public void Add(Pet newPet)
        {

                if (!_petsInTheStore.Contains(newPet))
                {
                    _petsInTheStore.Add(newPet);
                }
        }
    }

    public class ReadOnlySet<TItem> : IEnumerable<TItem>
    {
        readonly IEnumerable<TItem> _petsInTheStore;
        public ReadOnlySet(IEnumerable<TItem> pets)
        {
            this._petsInTheStore = pets;
        }   

        public IEnumerator<TItem> GetEnumerator() =>
            _petsInTheStore.OneAtATime().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}