using System;
using System.Collections.Generic;
using System.Collections.Immutable;

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
            List<Pet> cats = new List<Pet>(); 
            
            foreach (var cat in _petsInTheStore)
            {

                if (cat.species == Species.Cat)
                {
                    cats.Add(cat);
                }
            }

            return new ReadOnlySet<Pet>(cats);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var list = new List<Pet>(_petsInTheStore);
            list.Sort(comparison: (pet1, pet2) => { return pet1.name.CompareTo(pet2.name);});
            return list;
        }
    }
}