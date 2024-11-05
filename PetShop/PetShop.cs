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

        public void Add(Pet newPet)
        {

            if (!_petsInTheStore.Contains(newPet))
            {
                _petsInTheStore.Add(newPet);
            }
        }

        public IEnumerable<Pet> AllCats()
        {
            return _petsInTheStore.WherePredicate(p => p.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.WherePredicate(PetExtension.IsMice);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.WherePredicate(PetExtension.IsFemale);
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.WherePredicate(p => PetExtension.IsACat(p) || PetExtension.IsADog(p));
        }


        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.WherePredicate(p => p.species != Species.Mouse);
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.WherePredicate(PetExtension.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.WherePredicate(p => p.yearOfBirth > 2010 && p.species == Species.Dog);

        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.WherePredicate(p => p.species == Species.Dog && p.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.WherePredicate(p => p.yearOfBirth > 2011 || p.species == Species.Rabbit);

        }
    }
}