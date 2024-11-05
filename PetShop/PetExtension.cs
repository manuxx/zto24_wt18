using System;
using Training.DomainClasses;

public static class PetExtension
{
    public static bool IsSpeciesOf(Pet p, Species specie)
    {
        return p.species == specie;
    }

    public static bool IsFemale(Pet p)
    {
        return p.sex == Sex.Female;
    }

    public static bool IsMice(Pet p)
    {
        return PetExtension.IsSpeciesOf(p, Species.Mouse);
    }

    public static bool IsADog(Pet p)
    {
        return PetExtension.IsSpeciesOf(p, Species.Dog);
    }

    public static bool IsACat(Pet p)
    {
        return PetExtension.IsSpeciesOf(p,Species.Cat);
    }

    public static Predicate<Pet> IsBornAfter(int year)
    {
        return p => p.yearOfBirth > year;
    }
}