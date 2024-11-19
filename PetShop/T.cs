using System;

namespace Training.DomainClasses
{
    public class Pet : IEquatable<Pet>
    {
        public bool Equals(Pet other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return name == other.name;
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Pet)obj);
        }

        public override int GetHashCode()
        {
            return (name != null ? name.GetHashCode() : 0);
        }

        public static bool operator ==(Pet left, Pet right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Pet left, Pet right)
        {
            return !Equals(left, right);
        }

        public Sex sex;
        public string name { get; set; }
        public int yearOfBirth { get; set; }
        public float price { get; set; }
        public Species species { get; set; }

        public static Criteria<Pet> IsASpeciesOf(Species species)
        {
            return new SpeciesCriteria(species);
        }

        public static Criteria<Pet> IsFemale()
        {
            return new SexCriteria(Sex.Female);
        }

        public static Criteria<Pet> IsMale()
        {
            return new SexCriteria(Sex.Male);
        }

        public static Criteria<Pet> IsBornAfter(int year)
        {
            return new BornAfterCriteria(year);
        }
    }

    public class BornAfterCriteria(int year) : Criteria<Pet>
    {

        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.yearOfBirth > year;
        }
    }

    public class SexCriteria(Sex sex) : Criteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.sex == sex;
        }
    }

    public class SpeciesCriteria(Species species) : Criteria<Pet>
    {
        public bool IsSatisfiedBy(Pet pet)
        {
            return pet.species == species;
        }
    }
}