using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;

namespace PetShop
{
    public class PetShop(IList<Pet> petsInTheStore)
    {
        public IEnumerable<Pet> AllPets()
        {
            return new ReadOnlySet<Pet>(petsInTheStore);
        }

        public void Add(Pet newPet)
        {
            if (!petsInTheStore.Contains(newPet))
            {
                petsInTheStore.Add(newPet);
            }
        }

        public IEnumerable<Pet> AllCats()
        {
            foreach (var pet in petsInTheStore)
            {
                if (pet.species == Species.Cat)
                {
                    yield return pet;
                }
            }
        }

        public IEnumerable<Pet> AllPetsSortedByName()
        {
            var comparer = new NameComparer();
            var pets = new List<Pet>(petsInTheStore);
            pets.Sort(comparer);
            return pets;
        }
    }
}