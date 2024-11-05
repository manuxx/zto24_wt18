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
            return MYMETHOD(pet => pet.species == Species.Mouse);
        }

        private IEnumerable<Pet> MYMETHOD(Func<Pet, bool> parametr)
        {
            foreach (var pet in _petsInTheStore)
            {
                if (parametr(pet))
                    yield return pet;
            }
        }

        public IEnumerable<Pet> AllFemalePets()
        {
            return MYMETHOD(pet => pet.sex == Sex.Female);

            
        }

        public IEnumerable<Pet> AllCatsOrDogs()
        {
            return MYMETHOD(pet => pet.species == Species.Cat || pet.species == Species.Dog);

         
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return MYMETHOD(pet => pet.species != Species.Mouse);

           
        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return MYMETHOD(pet => pet.species == Species.Dog && pet.sex == Sex.Male);

          
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return MYMETHOD(pet => pet.yearOfBirth > 2010);

          
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return MYMETHOD(pet => pet.yearOfBirth > 2010 && pet.species == Species.Dog);


        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return MYMETHOD(pet => pet.yearOfBirth > 2011 || pet.species == Species.Rabbit);

            
        }
    }
}