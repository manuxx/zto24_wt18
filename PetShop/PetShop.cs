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
            return _petsInTheStore.AllItemsThat(new Alternative<Pet>(Pet.IsASpeciesOf(Species.Cat),Pet.IsASpeciesOf(Species.Dog)));
        }

        public IEnumerable<Pet> AllPetsButNotMice()
        {
            return _petsInTheStore.AllItemsThat(new Negation<Pet>(Pet.IsASpeciesOf(Species.Mouse)));
        }

        public IEnumerable<Pet> AllPetsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(Pet.IsBornAfter(2010));
        }

        public IEnumerable<Pet> AllDogsBornAfter2010()
        {
            return _petsInTheStore.AllItemsThat(new Conjunction<Pet>(Pet.IsASpeciesOf(Species.Dog), Pet.IsBornAfter(2010)));

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

    public class Alternative<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria1;
        private readonly Criteria<TItem> _criteria2;

        public Alternative(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) || _criteria2.IsSatisfiedBy(item);
        }
    }

    public class Conjunction<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteria1;
        private readonly Criteria<TItem> _criteria2;

        public Conjunction(Criteria<TItem> criteria1, Criteria<TItem> criteria2)
        {
            _criteria1 = criteria1;
            _criteria2 = criteria2;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return _criteria1.IsSatisfiedBy(item) && _criteria2.IsSatisfiedBy(item); ;
        }
    }

    public class Negation<TItem> : Criteria<TItem>
    {
        private readonly Criteria<TItem> _criteriaForNegation;

        public Negation(Criteria<TItem> criteriaForNegation)
        {
            _criteriaForNegation = criteriaForNegation;
        }

        public bool IsSatisfiedBy(TItem item)
        {
            return ! _criteriaForNegation.IsSatisfiedBy(item);
        }
    }
}