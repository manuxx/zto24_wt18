using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;

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
            return new SortedSet<Pet>(_petsInTheStore, Comparer<Pet>.Create((p1, p2) =>
            {
                if (ReferenceEquals(p1, p2)) return 0;
                return string.Compare(p1.name, p2.name, StringComparison.Ordinal);
            }));
        }
    }
}