using System.Collections.Generic;
using Training.DomainClasses;

namespace PetShop
{
    public class PetShop(IList<Pet> petsInTheStore)
    {
        public IEnumerable<Pet> AllPets()
        {
            return petsInTheStore.OneAtTime();
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