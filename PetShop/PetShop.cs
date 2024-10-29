using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using Training.DomainClasses;

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

    public class ReadOnlySet<T>(IList<T> petsInTheStore) : IEnumerable<T>
    {
        public IEnumerator<T> GetEnumerator()
        {
            return petsInTheStore.OneAtTime().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}