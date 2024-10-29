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

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            for (int i = 0; i < this._petsInTheStore.Count - 1; i++)
                for (int j = 0; j < this._petsInTheStore.Count - i - 1; j++)
                    if (this._petsInTheStore[j].name.CompareTo(this._petsInTheStore[j + 1].name) > 0)
                    {
                        var p = this._petsInTheStore[j];
                        this._petsInTheStore[j] = this._petsInTheStore[j + 1];
                        this._petsInTheStore[j + 1] = p;
                    }
            return new ReadOnlySet<Pet>(_petsInTheStore);
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var item in _petsInTheStore)
            {
                if (item.species.Equals(Species.Cat))
                {
                    yield return item;
                }
            }
        }

        public void Add(Pet newPet)
        {

                if (!_petsInTheStore.Contains(newPet))
                {
                    _petsInTheStore.Add(newPet);
                }
        }
    }
}