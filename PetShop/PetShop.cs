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
    }
}