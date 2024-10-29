using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

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

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in _petsInTheStore)
            {
                if(pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort((p1, p2) => p1.name.CompareTo(p2.name));
            return list;
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