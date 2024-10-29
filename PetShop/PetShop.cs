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
                if(pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            List<Pet> sortedPets = [.._petsInTheStore];
            sortedPets.Sort((pet1, pet2) => string.Compare(pet1.name, pet2.name, StringComparison.Ordinal));
            return sortedPets;
        }
    }
}