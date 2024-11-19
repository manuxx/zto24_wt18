using System;
using System.Collections.Generic;
using System.Globalization;

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
            return _petsInTheStore.AllItemsThat(new Alternative<Pet>(new SpeciesCriteria(Species.Cat), new SpeciesCriteria(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllItemsThat(new Negation<Pet>(new SpeciesCriteria(Species.Mouse)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(new Conjunction<Pet>(new BornAfterCriteria(2010), new SpeciesCriteria(Species.Dog)));

        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllItemsThat((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllItemsThat((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));

        }
    }

    internal class Conjunction<T> : Criteria<T>
    {

        private Criteria<T> _criteria1;
        private Criteria<T> _criteria2;

        public Conjunction(Criteria<T> criteria1, Criteria<T> criteria2)
        {
            this._criteria1 = criteria1;
            this._criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item);
        }
    }

    internal class Alternative<T> : Criteria<T>
    {

        private Criteria<T> _criteria1;
        private Criteria<T> _criteria2;

        public Alternative(Criteria<T> criteria1, Criteria<T> criteria2)
        {
            this._criteria1 = criteria1;
            this._criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }

    internal class Negation<T> : Criteria<T>
    {
        private Criteria<T> _criteria;

        public Negation(Criteria<T> criteria)
        {
            this._criteria = criteria;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !this._criteria.IsSatisfiedBy(item);
        }
    }
}