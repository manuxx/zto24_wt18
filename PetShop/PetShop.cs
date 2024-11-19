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
            return _petsInTheStore.AllItemsThat(Pet.IsASpeciesOf(Species.Cat));
        }



        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsASpeciesOf(Species.Mouse));

        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsFemale());
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.AllItemsThat(new LogicOr<Pet>(Pet.IsASpeciesOf(Species.Cat), Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsASpeciesOf(Species.Mouse).Not());
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(new LogicAnd<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));

        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsASpeciesOf(Species.Dog).And(Pet.IsMale()));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsASpeciesOf(Species.Rabbit).Or(Pet.IsBornAfter(2011)));

        }
    }
}