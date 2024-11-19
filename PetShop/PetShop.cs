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
            return _petsInTheStore.AllItemsThat((pet => pet.species == Species.Cat || pet.species == Species.Dog));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllItemsThat(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
            // return _petsInTheStore.AllItemsThat((pet => pet.species != Species.Mouse));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(new Conjunction<Pet>(new SpeciesCritera(Species.Dog),
                new BornAfterCriteria(2010)));
                // (pet => pet.species == Species.Dog && pet.yearOfBirth >2010));

        }

        public IEnumerable<Pet> AllMaleDogs()
        {
            return _petsInTheStore.AllItemsThat((pet => pet.species == Species.Dog && pet.sex == Sex.Male));
        }

        public IEnumerable<Pet> AllPetsBornAfter2011OrRabbits()
        {
            return _petsInTheStore.AllItemsThat(new Alternative<Pet>(new SpeciesCritera(Species.Rabbit),
                new BornAfterCriteria(2011)));
            // return _petsInTheStore.AllItemsThat((pet => pet.species == Species.Rabbit || pet.yearOfBirth > 2011));

        }
    }

    public class Negation<T> : Criteria<T>
    {
        private readonly Criteria<T> _criteria;

        public Negation(Criteria<T> criteria)
        {
            _criteria = criteria;
        }

        public bool IsSatisfiedBy(T item)
        {
            return !_criteria.IsSatisfiedBy(item);
        }

    }
    public class Conjunction<T> : Criteria<T>
    {
        private readonly Criteria<T> _criteria;
        private readonly Criteria<T> _criteria2;

        public Conjunction(Criteria<T> criteria, Criteria<T> criteria2)
        {
            _criteria = criteria;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return (_criteria.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item));
        }
    }
    public class Alternative<T> : Criteria<T>
    {
        private readonly Criteria<T> _criteria;
        private readonly Criteria<T> _criteria2;

        public Alternative(Criteria<T> criteria, Criteria<T> criteria2)
        {
            _criteria = criteria;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(T item)
        {
            return (_criteria.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item));
        }
    }

}