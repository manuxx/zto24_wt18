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
            return _petsInTheStore.Condition(pet => pet.species == Species.Cat);
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.Condition(pet => pet.species == Species.Mouse);

        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.Condition(IsFemale());

        }

        private static Func<Pet, bool> IsFemale()
        {
            return pet => pet.sex== Sex.Female;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.Condition(pet => pet.species == Species.Cat || pet.species == Species.Dog);

        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.Condition(IsSpecies(Species.Mouse));
        }

        private static Func<Pet, bool> IsSpecies(Species species)
        {
            return pet => pet.species != species;
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {

            return _petsInTheStore.Condition(BornAfter(2010));
        }

        private static Func<Pet, bool> BornAfter(int year)
        {
            return pet => pet.yearOfBirth > year;
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.Condition(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);

        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.Condition(pet => pet.species == Species.Dog && pet.sex == Sex.Male);
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.Condition(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);
        }
    }
}