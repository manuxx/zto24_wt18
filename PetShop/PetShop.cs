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
                if (pet.species == Species.Cat)
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var result = new List<Pet>(_petsInTheStore);
            result.Sort((pet1, pet2) => pet1.name.CompareTo(pet2.name));
            return result;
        }

        public IEnumerable<Pet> AllMice()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.species == Species.Mouse);
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return _petsInTheStore.MYMETHOD(isFEMELE());

            
        }

        private static Func<Pet, bool> isFEMELE()
        {
            return pet => pet.sex == Sex.Female;
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.species == Species.Cat || pet.species == Species.Dog);

         
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.MYMETHOD(IsSpeciesOfNOT(Species.Mouse));

           
        }

        private static Func<Pet, bool> IsSpeciesOfNOT(Species spec)
        {
            return pet => pet.species != spec;
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.species == Species.Dog && pet.sex == Sex.Male);

          
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.yearOfBirth > 2010);

          
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);


        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.MYMETHOD(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);

            
        }
    }
}